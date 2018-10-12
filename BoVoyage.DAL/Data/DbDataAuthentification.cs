using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataAuthentification : DbDataBase, IDataAuthentification
	{
		public void AddAuthentification(Authentification authentification)
		{
			this.context.Authentifications.Add(authentification);
			this.context.SaveChanges();
		}

		public void DeleteAuthentification(int id)
		{
			Authentification authentification = this.context.Authentifications.SingleOrDefault(x => x.ID == id);
			this.context.Authentifications.Remove(authentification);
			this.context.SaveChanges();
		}

		public Authentification GetAuthentification(int id)
		{
			return this.context.Authentifications.SingleOrDefault(x => x.ID == id);
		}

        public Authentification GetAuthentification(string email)
        {
            return this.context.Authentifications.SingleOrDefault(x => x.Email == email);
        }

        public void UpdateAuthentification(Authentification authentification)
		{
			this.context.Authentifications.Attach(authentification);
			this.context.Entry(authentification).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}