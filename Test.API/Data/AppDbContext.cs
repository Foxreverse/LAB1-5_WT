using Microsoft.EntityFrameworkCore;
using TEST.Domain.Entities;

namespace Test.API.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Tovar> Tovary { get; set; }
		public DbSet<Category> Categories { get; set; }


		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



	}
}
