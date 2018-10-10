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
    public sealed class InsuranceTypeViewModel :BaseModelViewModel
    {
        [Required(ErrorMessage ="Le {0} est requis")]
        [StringLength(40,ErrorMessage ="Le champ {0} doit contenir au maximum {1} caractères")]
        [Display(Name = "Type d'assurance")]

        public string Type { get; set; }

        //public ICollection<Insurance> Insurances { get; set; }
    }
}