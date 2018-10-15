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
						State = BookingFileState.Pending
					};

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

					this.serviceBookingFile.AddBookingFile(bookingfile, insurancesID);
					bookingfile = this.serviceBookingFile.GetBookingFileWithInsurancesIncluded(bookingfile.SequentialNb);

					var getTravel = this.serviceTravel.GetTravel(travel);
					bookingfile.PricePerPerson = bookingfile.Insurances == null ? getTravel.PricePerPerson : bookingfile.Insurances.Sum(x => x.Price) + getTravel.PricePerPerson;

					//Si voyageur et client unique fait avancé le statut du dossier
					if (reservationViewModel.IsTraveler)
					{
						var birthDate = ((CustomerViewModel)Session["CUSTOMER"]).BirthDate;
						bookingfile.TotalPrice = bookingfile.PricePerPerson * DiscountTypeEnum.GetDiscount(birthDate, getTravel.DepartureDate);
					}
					if (bookingfile.NbTraveler == 1 && reservationViewModel.IsTraveler)
					{
						bookingfile.State = BookingFileState.InProgress;
					}

					this.serviceBookingFile.UpdateBookingFile(bookingfile);
					getTravel.AvailablePlaces -= bookingfile.NbTraveler;
					if (bookingfile.NbTraveler == 1 && reservationViewModel.IsTraveler)
					{
						Display("Votre réservation a bien été prise en compte, nous vous tenons informer de sa validation !");
						return RedirectToAction("index", "home");
					}
					else
					{
						var nb = bookingfile.Travelers == null ? 1 : bookingfile.Travelers.Count + 1;
						TempData["Number"] = nb;
						return RedirectToAction("AddTraveler", "Reservations", new { bookingfile = bookingfile.ID, traveler = nb });
					}
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
				reservationViewModel = new ReservationViewModel();

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

		// GET: Reservations/Create/6/8
		[Authentication(Type = "CUSTOMER")]
		public ActionResult AddTraveler(int bookingfile, int traveler)
		{
			var getBookingFile = this.serviceBookingFile.GetBookingFileWithTravelersAndInsurancesIncluded(bookingfile);

			var customerIsTraveler = (CustomerViewModel)Session["CUSTOMER"];

			if (getBookingFile == null || getBookingFile.CustomerID != ((CustomerViewModel)Session["CUSTOMER"]).ID)
				return HttpNotFound();

			var nbTravelers = getBookingFile.Travelers == null ? 1 : getBookingFile.Travelers.Count + 1;

			if (traveler == nbTravelers)
			{
				var model = new TravelerViewModel()
				{
					BookingFileID = getBookingFile.ID,
					SequentialNb = string.Format("{0}-{1}", getBookingFile.SequentialNb, traveler)
				};

				return View(model);
			}
			else
				return HttpNotFound();
		}

		// POST: Reservations/Create/6/8
		[Authentication(Type = "CUSTOMER")]
		[HttpPost]
		public ActionResult AddTraveler(int BookingFileID, TravelerViewModel model)
		{
			if (model == null)
				return HttpNotFound();

			try
			{
				if (ModelState.IsValid)
				{
					var bookingFile = this.serviceBookingFile.GetBookingFileWithTravelersAndInsurancesIncluded(BookingFileID);

					var nb = bookingFile.Travelers == null ? 1 : bookingFile.Travelers.Count + 1;
					var traveler = new Traveler()
					{
						Civility = model.Civility,
						FirstName = model.FirstName,
						LastName = model.LastName,
						Address = model.Address,
						BirthDate = model.BirthDate,
						PhoneNumber = model.PhoneNumber,
						SequentialNb = string.Format("{0}-{1}", bookingFile.SequentialNb, nb)
					};

					bookingFile.Travelers.Add(traveler);
					bookingFile.TotalPrice += bookingFile.PricePerPerson * DiscountTypeEnum.GetDiscount(traveler.BirthDate, bookingFile.Travel.DepartureDate);
					this.serviceBookingFile.UpdateBookingFile(bookingFile);
					if (bookingFile.NbTraveler == bookingFile.Travelers.Count)
					{
						bookingFile.State = BookingFileState.InProgress;
						Display("Votre réservation a bien été prise en compte, nous vous tenons informer de sa validation !");
						return RedirectToAction("index", "home");
					}
					else
					{
						TempData["Number"] = nb + 1;
						return RedirectToAction("addtraveler", "reservations", new { bookingfile = bookingFile.ID, traveler = bookingFile.Travelers.Count + 1 });
					}
				}
				else
				{
					return View(model);
				}
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				// Penser à supprimer le booking file
				return RedirectToAction("index", "home");
			}
		}
	}
}