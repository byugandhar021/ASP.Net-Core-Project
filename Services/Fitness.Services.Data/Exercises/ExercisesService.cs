namespace Fitness.Services.Data.Exercises
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Repositories;
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;
    using Fitness.Web.ViewModels.Exercise;

    public class ExercisesService : IExercisesService
    {
        private readonly IDeletableEntityRepository<Exercise> exerciseRepository;

        public ExercisesService(IDeletableEntityRepository<Exercise> deletableEntityRepository)
        {
            this.exerciseRepository = deletableEntityRepository;
        }

        public async Task CreateExerciseAsync(string userId, CreateInputModel inputModel)
        {
            var exercise = new Exercise
            {
                Name = inputModel.Name,
                Video = inputModel.Video,
                Description = inputModel.Description,
                UserId = userId,
                CategoryId = "05cece71-9d11-4c6a-96a2-4115e546832b",
            };

            await this.exerciseRepository.AddAsync(exercise);
            await this.exerciseRepository.SaveChangesAsync();
        }

        public Task DeleteExerciseById(string exerciseId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAllExercises<T>()
        {
            return this.exerciseRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();
        }

        public T GetExerciseById<T>(string exerciseId)
        {
            var exercise = this.exerciseRepository
                .AllAsNoTracking()
                .Where(x => x.Id == exerciseId)
                .To<T>()
                .FirstOrDefault();

            return exercise;
        }

        public Task UpdateExerciseAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
