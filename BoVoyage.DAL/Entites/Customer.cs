﻿using BoVoyage.DAL.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Customer : BasePerson
	{
		[Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreatedOn { get; set; }

		public ICollection<BookingFile> BookingFiles { get; set; }
	}
}