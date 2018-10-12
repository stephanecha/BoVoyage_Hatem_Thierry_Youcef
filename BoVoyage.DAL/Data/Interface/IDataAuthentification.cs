using BoVoyage.DAL.Entites;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataAuthentification
	{
		Authentification GetAuthentification(int id);

        Authentification GetAuthentification(string email);

        void AddAuthentification(Authentification authentification);

		void UpdateAuthentification(Authentification authentification);

		void DeleteAuthentification(int id);
	}
}