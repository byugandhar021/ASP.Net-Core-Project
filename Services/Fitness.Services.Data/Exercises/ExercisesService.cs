namespace Fitness.Services.Data.Exercises
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Repositories;
    using Fitness.Data.Models;

    public class ExercisesService : IExercisesService
    {
        private readonly IDeletableEntityRepository<Exercise> exerciseRepository;

        public ExercisesService(IDeletableEntityRepository<Exercise> deletableEntityRepository)
        {
            this.exerciseRepository = deletableEntityRepository;
        }

        public Task CreateExerciseAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteExerciseById(string exerciseId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return this.exerciseRepository
                 .All()
                 .OrderByDescending(x => x.CreatedOn)
                 .ToList();
        }

        public Exercise GetExerciseById(string exerciseId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateExerciseAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
