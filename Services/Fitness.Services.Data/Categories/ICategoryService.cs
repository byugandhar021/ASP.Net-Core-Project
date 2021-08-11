namespace Fitness.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;
    using Fitness.Web.ViewModels.Diet;

    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategory();

        Task CreateCategoryAsync(string categoryName);

        Category GetCategoryById(string dietId);

        Task UpdateCategoryAsync(EditInputModel editInputModel);

        Task DeleteCategoryById(string dietId);
    }
}
