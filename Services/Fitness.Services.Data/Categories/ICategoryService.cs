namespace Fitness.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;
    using Fitness.Web.ViewModels.Category;

    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();

        IEnumerable<T> GetAllCategories<T>();

        Task CreateCategoryAsync(CreateInputModel categoryName);

        Category GetCategoryById(string dietId);

        Task UpdateCategoryAsync(EditInputModel editInputModel);

        Task DeleteCategoryById(string dietId);
    }
}
