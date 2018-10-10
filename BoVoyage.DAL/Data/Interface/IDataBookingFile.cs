using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataBookingFile
	{
		IEnumerable<BookingFile> GetAllBookingFiles();

		BookingFile GetBookingFile(int id);

		void AddBookingFile(BookingFile bookingFile);

		void UpdateBookingFile(BookingFile bookingFile);

		void DeleteBookingFile(int id);
	}
}