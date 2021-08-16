namespace Fitness.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Fitness.Services.Data.Gyms;
    using Fitness.Web.ViewModels.Gym;
    using Microsoft.AspNetCore.Mvc;

    public class GymController : Controller
    {
        private readonly IGymsService gymsService;

        public GymController(IGymsService gymsService)
        {
            this.gymsService = gymsService;
        }

        public IActionResult All()
        {
            var viewModel = new AllViewModel
            {
                Gyms = this.gymsService.GetAllGyms<SingleGymViewModel>(),
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

            await this.gymsService.CreateGymAsync(userId, inputModel);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.gymsService.GetGymById<DetailsViewModel>(id);
            return this.View(viewModel);
        }
    }
}
