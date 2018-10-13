using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataBookingFile
	{
		IEnumerable<BookingFile> GetAllBookingFiles();

		BookingFile GetBookingFile(int id);

		BookingFile GetBookingFile(string sequentialNb);

		BookingFile GetBookingFileWithInsurancesIncluded(string sequentialNb);

		void AddBookingFile(BookingFile bookingFile, int[] insurancesID);

		void UpdateBookingFile(BookingFile bookingFile);

		void DeleteBookingFile(int id);
	}
}