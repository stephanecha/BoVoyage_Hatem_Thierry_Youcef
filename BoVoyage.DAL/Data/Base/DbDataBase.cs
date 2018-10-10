using BoVoyage.DAL.Context;

namespace BoVoyage.DAL.Data.Base
{
	public abstract class DbDataBase
	{
		protected readonly DataContext context = new DataContext();
	}
}