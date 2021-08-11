namespace Fitness.Services.Data.Nutritions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;

    public interface INutritionsService
    {
        IEnumerable<Nutrition> GetAllNutritions();

        Task CreateNutritionAsync(string userId);

        Nutrition GetNutritionById(string nutritionId);

        Task UpdateNutritionAsync();

        Task DeleteNutritionById(string nutritionId);
    }
}
