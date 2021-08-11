namespace Fitness.Web.Controllers
{
    using Fitness.Services.Data.Diets;
    using Fitness.Web.ViewModels.Diet;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class DietController : BaseController
    {
        private readonly ICategoryService dietsService;

        public DietController(ICategoryService dietsService)
        {
            this.dietsService = dietsService;
        }

        public IActionResult All()
        {
            var diets = this.dietsService.GetAllDiets();
            return this.View(diets);
        }

        public IActionResult AllByCategory()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInputModel model)
        {
            await this.dietsService.CreateDietAsync(this.User.FindFirstValue(ClaimTypes.NameIdentifier), model);
            return RedirectToAction("All");
        }
    }
}
