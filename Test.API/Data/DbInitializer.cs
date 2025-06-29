using Microsoft.EntityFrameworkCore;
using TEST.Domain.Entities;

namespace Test.API.Data
{
	public static class DbInitializer
	{
		public static async Task SeedData(WebApplication app)
		{

			// Uri проекта
			var uri = "https://localhost:7002/";
			// Получение контекста БД
			using var scope = app.Services.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

			//Выполнение миграций
			await context.Database.MigrateAsync();

			if (!context.Categories.Any() && !context.Tovary.Any())
			{
				var _categories = new Category[]
			{
			new Category {GroupName="Товар 1",
			NormalizedName="Товар в коробке"},
			new Category {GroupName="Товар 2",
			NormalizedName="Товар в мешках"},
			new Category {GroupName="Товар 3",
			NormalizedName="Товар в стекле"}
			};

				await context.Categories.AddRangeAsync(_categories);
				await context.SaveChangesAsync();


				var _tovar = new List<Tovar>
		{
			new Tovar {Name = "Коробка 20*30",
					Description = "Картонная красная ",
					Image = uri + "Images/011.png",
					Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Товар в коробке")) },

				new Tovar { Name = "Коробка 25*60",
					Description = "Картонная синяя",
					Image = uri + "Images/012.png",
					Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Товар в коробке")) },


				new Tovar { Name = "Мешок 10*30 ",
					Description = "Мешок ткань",
					Image = uri + "Images/013.png",
					Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Товар в мешках")) },


				new Tovar {Name = "Мешок 30*45",
					Description = "Мешок полиэстер ",
					Image = uri + "Images/014.png",
					Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Товар в мешках")) },


				new Tovar {Name = "Коробка",
					Description = "Картонная ",
					Image = uri + "Images/015.png",
					Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Товар в коробке")) }


			};

				await context.Tovary.AddRangeAsync(_tovar);
				await context.SaveChangesAsync();

			}
		}
	}
}
