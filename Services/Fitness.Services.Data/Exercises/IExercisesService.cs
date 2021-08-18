namespace Fitness.Services.Data.Exercises
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;
    using Fitness.Web.ViewModels.Exercise;

    public interface IExercisesService
    {
        IEnumerable<T> GetAllExercises<T>();

        Task CreateExerciseAsync(string userId, CreateInputModel inputModel);

        Exercise GetExerciseById(string exerciseId);

        Task UpdateExerciseAsync();

        Task DeleteExerciseById(string exerciseId);
    }
}
