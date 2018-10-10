using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
    public sealed class DestinationViewModel : BaseModelViewModel
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string Continent { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(40)]
        public string Aera { get; set; }

        public string Description { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [Display(Name = "Destinations")]
        public ICollection<Travel> Travels { get; set; }

    }
}