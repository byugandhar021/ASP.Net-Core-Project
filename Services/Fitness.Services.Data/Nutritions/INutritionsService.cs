namespace Fitness.Services.Data.Nutritions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;
    using Fitness.Web.ViewModels.Nutrition;

    public interface INutritionsService
    {
        IEnumerable<T> GetAllNutritions<T>();

        Task CreateNutritionAsync(string userId, CreateNutritionInputModel model);

        T GetDietById<T>(string nutritionId);

        Task UpdateNutritionAsync(string id, EditNutritionInputModel model);

        Task DeleteNutritionById(string nutritionId);
    }
}
