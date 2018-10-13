using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceBookingFile
	{
		private readonly IDataBookingFile dataBookingFile;

		public ServiceBookingFile(IDataBookingFile dataBookingFile)
		{
			this.dataBookingFile = dataBookingFile;
		}

		public IEnumerable<BookingFile> GetAllBookingFiles()
		{
			return this.dataBookingFile.GetAllBookingFiles();
		}

		public IEnumerable<BookingFile> GetAllBookingFilesWithTravelsAndDestinationsIncluded(int CustomerID)
		{
			return this.dataBookingFile.GetAllBookingFiles().Where(x => x.CustomerID == CustomerID);
		}

		public BookingFile GetBookingFile(int id)
		{
			return this.dataBookingFile.GetBookingFile(id);
		}

		public BookingFile GetBookingFile(string sequentialNb)
		{
			return this.dataBookingFile.GetBookingFile(sequentialNb);
		}

		public BookingFile GetBookingFileWithInsurancesIncluded(string sequentialNb)
		{
			return this.dataBookingFile.GetBookingFileWithInsurancesIncluded(sequentialNb);
		}

		public void AddBookingFile(BookingFile bookingFile, int[] insurancesID)
		{
			//TODO: TESTS A FAIRE
			this.dataBookingFile.AddBookingFile(bookingFile, insurancesID);
		}

		public void UpdateBookingFile(BookingFile bookingFile)
		{
			//TODO: TESTS A FAIRE
			this.dataBookingFile.UpdateBookingFile(bookingFile);
		}

		public void DeleteBookingFile(int id)
		{
			this.dataBookingFile.DeleteBookingFile(id);
		}
	}
}