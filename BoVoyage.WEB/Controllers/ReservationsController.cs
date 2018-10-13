using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.DAL.Entites.Enum;
using BoVoyage.WEB.Controllers.Base;
using BoVoyage.WEB.Filters;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BoVoyage.WEB.Controllers
{
	public class ReservationsController : BaseController
	{
		private readonly ServiceBookingFile serviceBookingFile;
		private readonly ServiceCustomer serviceCustomer;
		private readonly ServiceTravel serviceTravel;
		private readonly ServiceInsurance serviceInsurance;

		public ReservationsController()
		{
			this.serviceBookingFile = new ServiceBookingFile(new DbDataBookingFile());
			this.serviceCustomer = new ServiceCustomer(new DbDataAuthentification(), new DbDataCustomer());
			this.serviceTravel = new ServiceTravel(new DbDataTravel());
			this.serviceInsurance = new ServiceInsurance(new DbDataInsurance());
		}

		// GET: Reservations/Create/6/8
		[Authentication(Type = "CUSTOMER")]
		public ActionResult Create(int customer, int travel)
		{
			ReservationViewModel reservationViewModel = new ReservationViewModel();

			var getCustomer = this.serviceCustomer.GetCustomerWithAuthentificationInclude(customer);
			if (getCustomer == null)
				return HttpNotFound();
			var customerViewModel = TransformModelCustomer.CustomerToModelView(getCustomer);
			reservationViewModel.CustomerViewModel = customerViewModel;

			var getTravel = this.serviceTravel.GetTravelWithDestinationIncluded(travel);
			if (getTravel == null)
				return HttpNotFound();
			var travelViewModel = TransformModelTravel.TravelToModelView(getTravel);
			reservationViewModel.TravelViewModel = travelViewModel;

			ViewBag.Insurances = new MultiSelectList(this.serviceInsurance.GetAllInsurancesWithTypesIncluded(), "ID", "FullName");

			return View(reservationViewModel);
		}

		// POST: Reservations/SelectNbTravelers
		[HttpPost]
		[Authentication(Type = "CUSTOMER")]
		public ActionResult Create(int customer, int travel, ReservationViewModel reservationViewModel, int[] insurancesID)
		{
			try
			{
				if (reservationViewModel == null)
					HttpNotFound();

				// TODO: Add insert logic here
				if (ModelState.IsValid)
				{
					//Création du Bookingfile
					var bookingfile = new BookingFile()
					{
						CustomerID = customer,
						TravelID = travel,
						CreditCardNb = reservationViewModel.CreditCardNb,
						NbTraveler = reservationViewModel.NbTraveler,
						SequentialNb = string.Format("{0}-{1}-{2}-{3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), customer, travel),
						State = DAL.Entites.Enum.BookingFileState.Pending
					};

					//Ajout des potentiels assurances
					if (insurancesID != null)
						bookingfile.Insurances = (System.Collections.Generic.ICollection<Insurance>)this.serviceInsurance.GetAllSelectedInsurances(insurancesID);

					//Ajout d'un Participant si le client en fait partie
					if (reservationViewModel.IsTraveler)
					{
						var customerIsTraveler = (CustomerViewModel)Session["CUSTOMER"];
						var traveler = new Traveler()
						{
							Civility = customerIsTraveler.Civility,
							FirstName = customerIsTraveler.FirstName,
							LastName = customerIsTraveler.LastName,
							Address = customerIsTraveler.Address,
							BirthDate = customerIsTraveler.BirthDate,
							PhoneNumber = customerIsTraveler.PhoneNumber,
							SequentialNb = string.Format("{0}-1", bookingfile.SequentialNb),
						};
						bookingfile.Travelers = new List<Traveler>
						{
							traveler
						};
					}

					//Cacul du prix par personne et du prix total
					var getTravel = this.serviceTravel.GetTravelWithDestinationIncluded(travel);
					bookingfile.PricePerPerson = bookingfile.Insurances == null ? getTravel.PricePerPerson : bookingfile.Insurances.Sum(x => x.Price) + getTravel.PricePerPerson;

					if (bookingfile.NbTraveler == 1 && reservationViewModel.IsTraveler)
					{
						var birthDate = bookingfile.Travelers.First().BirthDate;
						bookingfile.TotalPrice = bookingfile.PricePerPerson * DiscountTypeEnum.GetDiscount(birthDate, getTravel.DepartureDate);
						bookingfile.State = BookingFileState.InProgress;
					}

					this.serviceBookingFile.AddBookingFile(bookingfile);

					if (bookingfile.NbTraveler == 1 && reservationViewModel.IsTraveler)
					{
						Display("Votre réservation a bien été prise en compte, nous vous tenons informer de sa validation !");
					}
					else
					{
						Display("Votre réservation a bien été prise en compte, veuillez la compléter pour la valider !");
					}
					return RedirectToAction("index", "home");
				}
				else
				{
					var getCustomer = this.serviceCustomer.GetCustomerWithAuthentificationInclude(customer);
					if (getCustomer == null)
						return HttpNotFound();
					var customerViewModel = TransformModelCustomer.CustomerToModelView(getCustomer);
					reservationViewModel.CustomerViewModel = customerViewModel;

					var getTravel = this.serviceTravel.GetTravelWithDestinationIncluded(travel);
					if (getTravel == null)
						return HttpNotFound();
					var travelViewModel = TransformModelTravel.TravelToModelView(getTravel);
					reservationViewModel.TravelViewModel = travelViewModel;

					ViewBag.Insurances = new MultiSelectList(this.serviceInsurance.GetAllInsurancesWithTypesIncluded(), "ID", "FullName");
					return View(reservationViewModel);
				}
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}
	}
}