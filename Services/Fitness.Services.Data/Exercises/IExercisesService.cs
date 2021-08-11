namespace Fitness.Services.Data.Exercises
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;

    public interface IExercisesService
    {
        IEnumerable<Exercise> GetAllExercises();

        Task CreateExerciseAsync(string userId);

        Exercise GetExerciseById(string exerciseId);

        Task UpdateExerciseAsync();

        Task DeleteExerciseById(string exerciseId);
    }
}
