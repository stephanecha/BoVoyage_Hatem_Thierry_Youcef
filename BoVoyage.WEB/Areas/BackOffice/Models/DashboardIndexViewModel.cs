using BoVoyage.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyage.WEB.Areas.BackOffice.Models
{
    public class DashboardIndexViewModel
    {
        public IEnumerable<Travel> TravelsInLessthan15Days { get; set; }

    }
}