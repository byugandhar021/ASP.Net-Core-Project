namespace Fitness.Services.Data.Nutritions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Repositories;
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;
    using Fitness.Web.ViewModels.Nutrition;

    public class NutritionsService : INutritionsService
    {
        private readonly IDeletableEntityRepository<Nutrition> nutritionRepository;

        public NutritionsService(IDeletableEntityRepository<Nutrition> nutritionRepository)
        {
            this.nutritionRepository = nutritionRepository;
        }

        public async Task CreateNutritionAsync(string userId, CreateNutritionInputModel model)
        {
            var nutrition = new Nutrition
            {
                Name = model.Name,
                Description = model.Description,
                Calories = model.Calories,
                CategoryId = model.CategoryId,
                Ingredients = model.Ingredients,
                UserId = model.UserId,
            };

            await this.nutritionRepository.AddAsync(nutrition);
            await this.nutritionRepository.SaveChangesAsync();
        }

        public async Task DeleteNutritionById(string nutritionId)
        {
            var nutrition = this.nutritionRepository
                .All()
                .FirstOrDefault(x => x.Id == nutritionId);

            this.nutritionRepository.Delete(nutrition);
            await this.nutritionRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllNutritions<T>()
        {
            var allNutritions = this.nutritionRepository
               .AllAsNoTracking()
               .OrderByDescending(x => x.Id)
               .To<T>()
               .ToList();

            return allNutritions;
        }

        public T GetDietById<T>(string nutritionId)
        {
            var nutrition = this.nutritionRepository
               .AllAsNoTracking()
               .Where(x => x.Id == nutritionId)
               .To<T>()
               .FirstOrDefault();

            return nutrition;
        }

        public async Task UpdateNutritionAsync(string id, EditNutritionInputModel model)
        {
            var nutrition = this.nutritionRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            nutrition.Name = model.Name;
            nutrition.Ingredients = model.Ingredients;
            nutrition.Description = model.Description;
            nutrition.Calories = model.Calories;

            this.nutritionRepository.Update(nutrition);
            await this.nutritionRepository.SaveChangesAsync();
        }
    }
}
