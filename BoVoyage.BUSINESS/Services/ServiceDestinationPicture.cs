using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.BUSINESS.Services
{
    public class ServiceDestinationPicture
    {
        private readonly IDataDestinationPicture dataDestinationPicture;

        public ServiceDestinationPicture(IDataDestinationPicture dataDestinationPicture)
        {
            this.dataDestinationPicture = dataDestinationPicture;
        }

        public void AddDestinationPicture(DestinationPicture destinationPicture)
        {
            //TODO: TESTS A FAIRE
            this.dataDestinationPicture.AddDestinationPicture(destinationPicture);
        }

        public void DeleteDestinationPicture(int id)
        {
            this.dataDestinationPicture.DeleteDestinationPicture(id);
        }

    }
}
