using TEST.Domain.Entities;
using TEST.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Test.UI.Services
{
	public class MemoryCategoryService : ICategoryService
    {
        public Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            var categories = new List<Category>
            {
            new Category {Id=1, GroupName="Товар 1",
            NormalizedName="Товар в коробке"},
            new Category {Id=2, GroupName="Товар 2",
            NormalizedName="Товар в машках"},
            new Category {Id=2, GroupName="Товар 3",
            NormalizedName="Товар в "}

            };
            var result = new ResponseData<List<Category>>();
            result.Data = categories;
            return Task.FromResult(result);
        }

       
    }
}
