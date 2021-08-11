namespace Fitness.Web.Controllers
{
    using Fitness.Services.Data.Diets;
    using Fitness.Web.ViewModels.Diet;
    using Microsoft.AspNetCore.Mvc;

    public class DietController : BaseController
    {
        private readonly IDietsService dietsService;

        public DietController(IDietsService dietsService)
        {
            this.dietsService = dietsService;
        }

        public IActionResult All()
        {
            var diets = this.dietsService.GetAllDiets();

            var viewModel = new AllViewModel
            {
                Diets = diets,
            };
            return this.View(diets);
        }

        public IActionResult AllByCategory()
        {
            return View();
        }
    }
}
