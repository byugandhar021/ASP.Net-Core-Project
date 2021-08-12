namespace Fitness.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

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
            var viewModel = new AllViewModel
            {
                Diets = this.dietsService.GetAllDiets<SingleDietViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult AllByCategory()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInputModel model)
        {
            await this.dietsService.CreateDietAsync(this.User.FindFirstValue(ClaimTypes.NameIdentifier), model);
            return this.RedirectToAction("All");
        }
    }
}
