using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using BoVoyage.WEB.Validators;
using BoVoyage.WEB.Validators.Enum;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
    public class TravelIndexSearchViewModel
    {

        [Display(Name = "Date aller")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DateBeforeAfterToday(CompareDateCase.AFTER, ErrorMessage = "Le champ {0} doit être après aujourd'hui.")]
        //TODO: Unique DepartureDate, ReturnDate, TravelAgencyID and DestinationID and PricePerPerson
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Date retour")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DateComparaison(CompareDateCase.AFTER, "DepartureDate", ErrorMessage = "Le champ {0} doit être après {1}")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Places disponibles")]
        [IntDecimalOverZero(ErrorMessage = "Le champ {0} doit être supérieur ou égal à 0.")]
        public int AvailablePlaces { get; set; }

        [Display(Name = "Prix par personne")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [IntDecimalOverZero(ErrorMessage = MessageType.MustBeOverZero)]
        [DataType(DataType.Currency)]
        public decimal PricePerPerson { get; set; }

        [Display(Name = "Agence de voyage")]
        [StringLength(40, ErrorMessage = MessageType.StringLengthField)]
        public string Name { get; set; }

        [Display(Name = "Continent")]
        [StringLength(40, ErrorMessage = MessageType.StringLengthField)]
        public string Continent { get; set; }

        [Display(Name = "Pays")]
        [StringLength(40, ErrorMessage = MessageType.StringLengthField)]
        public string Country { get; set; }

        [Display(Name = "Région")]
        [StringLength(40, ErrorMessage = MessageType.StringLengthField)]
        public string Area { get; set; }

        [Display(Name = "Ville")]
        [StringLength(40, ErrorMessage = MessageType.StringLengthField)]
        public string City { get; set; }
        
        public IEnumerable<TravelViewModel> TravelViewModel { get; set; }

    }
}