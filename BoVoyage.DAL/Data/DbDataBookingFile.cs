using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataBookingFile : DbDataBase, IDataBookingFile
	{
		public void AddBookingFile(BookingFile bookingFile)
		{
			this.context.BookingFiles.Add(bookingFile);
			this.context.SaveChanges();
		}

		public void DeleteBookingFile(int id)
		{
			BookingFile bookingFile = this.context.BookingFiles.SingleOrDefault(x => x.ID == id);
			this.context.BookingFiles.Remove(bookingFile);
			this.context.SaveChanges();
		}

		public IEnumerable<BookingFile> GetAllBookingFiles()
		{
			return this.context.BookingFiles.ToList();
		}

		public BookingFile GetBookingFile(int id)
		{
			return this.context.BookingFiles.SingleOrDefault(x => x.ID == id);
		}

		public void UpdateBookingFile(BookingFile bookingFile)
		{
			this.context.BookingFiles.Attach(bookingFile);
			this.context.Entry(bookingFile).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}