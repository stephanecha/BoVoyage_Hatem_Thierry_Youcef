using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
    public sealed class TravelViewModel : BaseModelViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public int AvailablePlaces { get; set; }

        [Required]
        public decimal PricePerPerson { get; set; }

        //[Display]
        public ICollection<BookingFile> BookingFiles { get; set; }
    }
}