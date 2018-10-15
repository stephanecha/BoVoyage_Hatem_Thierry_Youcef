using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.DAL.Data
{
    public class DbDataDestinationPicture : DbDataBase, IDataDestinationPicture
    {
        public void AddDestinationPicture(DestinationPicture destinationPicture)
        {
            this.context.destinationPicture.Add(destinationPicture);
            this.context.SaveChanges();
        }

        public void DeleteDestinationPicture(int id)
        {
            DestinationPicture destinationPicture = this.context.destinationPicture.SingleOrDefault(x => x.ID == id);
            this.context.destinationPicture.Remove(destinationPicture);
            this.context.SaveChanges();
        }

        

    }
}
