namespace Fitness.Services.Data.Diets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Repositories;
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;
    using Fitness.Web.ViewModels.Diet;

    public class DietsService : IDietsService
    {
        private readonly IDeletableEntityRepository<Diet> dietRepository;

        public DietsService(IDeletableEntityRepository<Diet> dietRepository)
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
                CategoryId = "eee111",
                UserId = userId,
            };

            await this.dietRepository.AddAsync(diet);
            await this.dietRepository.SaveChangesAsync();
        }

        public async Task DeleteDietByIdAsync(string dietId)
        {
            var diet = this.dietRepository
                .All()
                .FirstOrDefault(x => x.Id == dietId);

            this.dietRepository.Delete(diet);
            await this.dietRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllDiets<T>()
        {
            var allDiets = this.dietRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<T>()
                .ToList();

            return allDiets;
        }

        public T GetDietById<T>(string dietId)
        {
            var diet = this.dietRepository
                .AllAsNoTracking()
                .Where(x => x.Id == dietId)
                .To<T>()
                .FirstOrDefault();

            return diet;
        }

        public async Task UpdateDietAsync(string id, EditInputModel editInputModel)
        {
            var diet = this.dietRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            diet.Name = editInputModel.Name;
            diet.Duration = editInputModel.Duration;
            diet.Description = editInputModel.Description;
            diet.UserId = editInputModel.UserId;

            this.dietRepository.Update(diet);
            await this.dietRepository.SaveChangesAsync();
        }
    }
}
