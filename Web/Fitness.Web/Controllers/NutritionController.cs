namespace Fitness.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Fitness.Services.Data.Categories;
    using Fitness.Services.Data.Nutritions;
    using Fitness.Web.ViewModels.Nutrition;
    using Microsoft.AspNetCore.Mvc;

    public class NutritionController : Controller
    {
        private readonly INutritionsService nutritionsService;
        private readonly ICategoryService categoryService;

        public NutritionController(INutritionsService nutritionsService, ICategoryService categoryService)
        {
            this.nutritionsService = nutritionsService;
            this.categoryService = categoryService;
        }

        public IActionResult All()
        {
            var viewModel = new AllNutritionViewModel
            {
                Nutritions = this.nutritionsService.GetAllNutritions<SingleNutritionViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult AllByCategory()
        {
            return this.View();
        }

        public IActionResult Create(string category)
        {
            var model = new CreateNutritionInputModel { Category = category };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string category, CreateNutritionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var ccategory = this.categoryService.GetCategoryByName(category);
            model.CategoryId = ccategory.Id;

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.UserId = userId;

            await this.nutritionsService.CreateNutritionAsync(userId, model);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.nutritionsService.GetDietById<DetailsNutritionViewModel>(id);
            return this.View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            var inputModel = this.nutritionsService.GetDietById<EditNutritionInputModel>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditNutritionInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.nutritionsService.UpdateNutritionAsync(id, inputModel);
            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.nutritionsService.DeleteNutritionById(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
