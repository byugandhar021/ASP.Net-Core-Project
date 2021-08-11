namespace Fitness.Web.Controllers
{
    using Fitness.Services.Data.Exercises;
    using Microsoft.AspNetCore.Mvc;

    public class ExerciseController : Controller
    {
        private readonly IExercisesService exercisesService;

        public ExerciseController(IExercisesService exercisesService)
        {
            this.exercisesService = exercisesService;
        }

        public IActionResult All()
        {
            var exercise = this.exercisesService.GetAllExercises();
            return this.View(exercise);
        }
    }
}
