using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyage.WEB.Tools
{
    public class TransformModelCustomer
    {
        public static Customer CustomerModelViewToModel(CustomerViewModel customerViewModel)
        {
            Customer customer = new Customer()
            {
                ID = customerViewModel.ID,
                Civility = customerViewModel.Civility,
                FirstName = customerViewModel.FirstName,
                LastName = customerViewModel.LastName,
                BirthDate = customerViewModel.BirthDate,
                Address = customerViewModel.Address,
                PhoneNumber = customerViewModel.PhoneNumber,
                //BookingFiles = customerViewModel.BookingFiles
                
                
            };

            return customer;
        }
    }
}