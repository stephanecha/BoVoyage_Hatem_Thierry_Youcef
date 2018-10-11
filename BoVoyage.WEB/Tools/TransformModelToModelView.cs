using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyage.WEB.Tools
{
    public static class TransformModelToModelView
    {
        public static List<InsuranceViewModel> InsuranceToModelView(IEnumerable<Insurance> listAssurances)
        {
            List<InsuranceViewModel> assuranceViewModel = new List<InsuranceViewModel>(listAssurances.Select(x =>
                new InsuranceViewModel()
                {
                    ID = x.ID,
                    Description = x.Description,
                    Price = x.Price,
                    InsuranceTypeID = x.InsuranceTypeID,
                    InsuranceType = x.InsuranceType
                }).ToList());
            return assuranceViewModel;
        }
    }
}