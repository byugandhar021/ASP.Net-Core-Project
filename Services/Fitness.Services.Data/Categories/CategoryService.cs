namespace Fitness.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Repositories;
    using Fitness.Data.Models;
    using Fitness.Web.ViewModels.Diet;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(string categoryName)
        {
            var category = new Category
            {
                Name = categoryName,
            };

            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryById(string dietId)
        {
            var diet = this.categoryRepository.All().Where(x => x.Id == dietId).FirstOrDefault();
            this.categoryRepository.Delete(diet);
            await this.categoryRepository.SaveChangesAsync();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            var allDiets = this.categoryRepository
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return allDiets;
        }

        public Category GetCategoryById(string dietId)
        {
            var diet = this.categoryRepository.All().Where(x => x.Id == dietId).FirstOrDefault();
            return diet;
        }

        public async Task UpdateCategoryAsync(EditInputModel editInputModel)
        {
            var category = new Category();
                ////this.categoryRepository.All().Where(x => x.Id == editInputModel.Id).FirstOrDefault();

            ////diet.Name = editInputModel.Name;
            ////diet.Duration = editInputModel.Duration;
            ////diet.Description = editInputModel.Description;
            ////diet.UserId = editInputModel.UserId;

            this.categoryRepository.Update(category);
            await this.categoryRepository.SaveChangesAsync();
        }
    }
}
