using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVCWithData.Models;

namespace AspNetCoreMVCWithData.Data {
	public class AspNetCoreMVCWithDataContext : DbContext {
		public AspNetCoreMVCWithDataContext(DbContextOptions<AspNetCoreMVCWithDataContext> options) : base(options) {

		}

		public DbSet<Book> Book { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Book>().HasData(new Book {
				Id = 1,
				Title="Book1",
				Genre = "Genre1",
				Price = 20,
				PublishDate = new DateTime(2012, 4, 23)
			}, new Book {
				Id = 2,
				Title = "Book2",
				Genre = "Genre2",
				Price = 30,
				PublishDate = new DateTime(2008, 6, 13)
			});
		}
	}
}
