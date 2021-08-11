namespace Fitness.Services.Data.Diets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Repositories;
    using Fitness.Data.Models;
    using Fitness.Web.ViewModels.Diet;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Diet> dietRepository;

        public CategoryService(IDeletableEntityRepository<Diet> dietRepository)
        {
            this.dietRepository = dietRepository;
        }

        public async Task CreateDietAsync(string userId, CreateInputModel createInputModel)
        {
            var diet = new Diet
            {
                Name = createInputModel.Name,
                Duration = createInputModel.Duration,
                Description = createInputModel.Description,
                CategoryId = createInputModel.CategoryId,
                UserId = userId,
            };

            await this.dietRepository.AddAsync(diet);
            await this.dietRepository.SaveChangesAsync();
        }

        public async Task DeleteDietById(string dietId)
        {
            var diet = this.dietRepository.All().Where(x => x.Id == dietId).FirstOrDefault();
            this.dietRepository.Delete(diet);
            await this.dietRepository.SaveChangesAsync();
        }

        public IEnumerable<Diet> GetAllDiets()
        {
            var allDiets = this.dietRepository
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return allDiets;
        }

        public Diet GetDietById(string dietId)
        {
            var diet = this.dietRepository.All().Where(x => x.Id == dietId).FirstOrDefault();
            return diet;
        }

        public async Task UpdateDietAsync(EditInputModel editInputModel)
        {
            var diet = this.dietRepository.All().Where(x => x.Id == editInputModel.Id).FirstOrDefault();

            diet.Name = editInputModel.Name;
            diet.Duration = editInputModel.Duration;
            diet.Description = editInputModel.Description;
            diet.UserId = editInputModel.UserId;

            this.dietRepository.Update(diet);
            await this.dietRepository.SaveChangesAsync();
        }
    }
}
