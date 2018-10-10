using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyage.WEB.Models
{
    public class InsuranceViewModel : BaseModelViewModel
    {
        [Required(ErrorMessage = "Le {0} est requis")]
        [Display(Name ="Prix par personne")]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "La {0} est requise")]
        public string Description { get; set; }

        [Display(Name = "Type d'assurance")]
        [Required(ErrorMessage = "Le {0} est requis")]
        public int InsuranceTypeID { get; set; }



        // A supprimer ??
        public InsuranceType InsuranceType { get; set; }//FK

        //public ICollection<BookingFile> BookingFiles { get; set; }
    }
}