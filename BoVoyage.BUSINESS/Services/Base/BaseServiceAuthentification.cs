using BoVoyage.DAL.Data.Interface;

namespace BoVoyage.BUSINESS.Services.Base
{
	public abstract class BaseServiceAuthentification
	{
		private readonly IDataAuthentification dataAuthentification;

		protected BaseServiceAuthentification(IDataAuthentification dataAuthentification)
		{
			this.dataAuthentification = dataAuthentification;
		}
	}
}