namespace Fitness.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Fitness.Services.Data.Exercises;
    using Fitness.Web.ViewModels.Exercise;
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
            var viewModel = new AllViewModel
            {
                Exercises = this.exercisesService.GetAllExercises<SingleViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.exercisesService.CreateExerciseAsync(userId, inputModel);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
