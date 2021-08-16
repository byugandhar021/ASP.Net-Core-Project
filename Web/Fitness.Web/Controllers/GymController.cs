namespace Fitness.Web.Controllers
{
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
    }
}
