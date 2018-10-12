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
            //Authentification authen = new Authentification()
            //{
            //    Password = customerViewModel.Password,
            //    ConfirmedPassword = customerViewModel.ConfirmedPassword,
            //    Email = customerViewModel.Email

            //};
            Customer customer = new Customer()
            {
                ID = customerViewModel.ID,
                Civility = customerViewModel.Civility,
                FirstName = customerViewModel.FirstName,
                LastName = customerViewModel.LastName,
                BirthDate = customerViewModel.BirthDate,
                Address = customerViewModel.Address,
                PhoneNumber = customerViewModel.PhoneNumber,
                CreatedOn = DateTime.Now
                
                
                
                //BookingFiles = customerViewModel.BookingFiles
                
                
            };
            customer.Authentification = new Authentification();
            customer.Authentification.Password = customerViewModel.Password;
            //customer.Authentification.ConfirmedPassword = customerViewModel.ConfirmedPassword;
            customer.Authentification.Email = customerViewModel.Email;
            //customer.Authentification.ID = customerViewModel.ID;


            return customer; 
        }
    }
}