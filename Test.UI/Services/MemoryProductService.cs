using TEST.Domain.Entities;
using TEST.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;
using Humanizer;

namespace Test.UI.Services
{

    public class MemoryProductService : IProductService
    {
        List<Tovar> _tovary;
        List<Category> _categories;
        IConfiguration _config;



        public MemoryProductService(ICategoryService categoryService, [FromServices] IConfiguration config)
        {
            _config = config;
            _categories = categoryService.GetCategoryListAsync()
                .Result
                .Data;

            SetupData();
        }

		



        /// <summary>
        /// Инициализация списков
        /// </summary>
        public void SetupData()
        {

            _tovary = new List<Tovar>
            {
                new Tovar { Id = 1, Name = "Коробка 20*30",
                    Description = "Картонная красная ",
                    Image = "Images/011.png",
                    CategoryId = _categories.Find(c => c.NormalizedName.Equals("Товар в коробке")).Id },

                new Tovar { Id = 1, Name = "Коробка 25*60",
                    Description = "Картонная синяя",
                    Image = "Images/012.png",
                    CategoryId = _categories.Find(c => c.NormalizedName.Equals("Товар в коробке")).Id },


                new Tovar { Id = 1, Name = "Мешок 10*30 ",
                    Description = "Мешок ткань",
                    Image = "Images/013.png",
                    CategoryId = _categories.Find(c => c.NormalizedName.Equals("Товар в коробке")).Id },


                new Tovar { Id = 1, Name = "Мешок 30*45",
                    Description = "Мешок полиэстер ",
                    Image = "Images/014.png",
                    CategoryId = _categories.Find(c => c.NormalizedName.Equals("Товар в коробке")).Id },


                new Tovar { Id = 1, Name = "Коробка",
                    Description = "Картонная ",
                    Image = "Images/015.png",
                    CategoryId = _categories.Find(c => c.NormalizedName.Equals("Товар в коробке")).Id }


            };
        }


		Task<ResponseData<ListModel<Tovar>>> IProductService.GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
		{


			// Создать объект результата
			var result = new ResponseData<ListModel<Tovar>>();

			// Id категории для фильрации
			int? categoryId = null;

			// если требуется фильтрация, то найти Id категории
			// с заданным categoryNormalizedName
			if (categoryNormalizedName != null)
				categoryId = _categories
				.Find(c =>
				c.NormalizedName.Equals(categoryNormalizedName))
				?.Id;

			// Выбрать объекты, отфильтрованные по Id категории,
			// если этот Id имеется
			var data = _tovary
			.Where(d => categoryNormalizedName == null || d.CategoryId.Equals(categoryNormalizedName))?
			.ToList();

			// получить размер страницы из конфигурации
			int pageSize = _config.GetSection("ItemsPerPage").Get<int>();


			// получить общее количество страниц
			int totalPages = (int)Math.Ceiling(data.Count / (double)pageSize);

			// получить данные страницы
			var listData = new ListModel<Tovar>()
			{
				Items = data.Skip((pageNo - 1) *
			pageSize).Take(pageSize).ToList(),
				CurrentPage = pageNo,
				TotalPages = totalPages
			};

			// поместить ранные в объект результата
			result.Data = listData;



			// Если список пустой
			if (data.Count == 0)
			{
				result.Success = false;
				result.ErrorMessage = "Нет объектов в выбраннной категории";
			}
			// Вернуть результат
			return Task.FromResult(result);

		}

		public Task<ResponseData<Tovar>> CreateProductAsync(Tovar product, IFormFile? formFile)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProductAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseData<Tovar>> GetProductByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		

		public Task UpdateProductAsync(int id, Tovar product, IFormFile? formFile)
		{
			throw new NotImplementedException();
		}
	}
}

            