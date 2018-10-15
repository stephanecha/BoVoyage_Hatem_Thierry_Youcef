using BoVoyage.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.DAL.Data.Interface
{
    public interface IDataDestinationPicture
    {
        void AddDestinationPicture(DestinationPicture destinationPicture);

        void DeleteDestinationPicture(int id);
    }
}
