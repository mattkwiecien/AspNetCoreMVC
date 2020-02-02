﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVCWithData.Models {
	public class Book {
		public int Id { get; set; }
		
		[Display(Name = "Book Title")]
		[Required]
		public string Title { get; set; }

		public string Genre { get; set; }

		[Range(1, 100)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		[Display(Name = "Publish Date")]
		[DataType(DataType.Date)]
		public DateTime PublishDate { get; set; }
	}
}
