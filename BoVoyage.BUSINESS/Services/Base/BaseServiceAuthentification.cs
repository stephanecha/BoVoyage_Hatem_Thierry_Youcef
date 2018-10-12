using BoVoyage.DAL.Data.Interface;

namespace BoVoyage.BUSINESS.Services.Base
{
	public abstract class BaseServiceAuthentification
	{
        protected readonly IDataAuthentification dataAuthentification;

		protected BaseServiceAuthentification(IDataAuthentification dataAuthentification)
		{
			this.dataAuthentification = dataAuthentification;
		}
	}
}