namespace Fitness.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Fitness.Data.Models;
    using Fitness.Services.Data.Categories;
    using Fitness.Services.Data.Diets;
    using Fitness.Web.ViewModels.Diet;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DietController : BaseController
    {
        private readonly IDietsService dietsService;
        private readonly ICategoryService categoryService;

        public DietController(IDietsService dietsService, ICategoryService categoryService)
        {
            this.dietsService = dietsService;
            this.categoryService = categoryService;
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

        public IActionResult Create(string category)
        {
            var model = new CreateInputModel { Category = category };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string category, CreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var category = this.categoryService.GetCategoryByName(category);
            model.CategoryId = roleId.Id;

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.dietsService.CreateDietAsync(userId, model);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.dietsService.GetDietById<DetailsViewModel>(id);
            return this.View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            var inputModel = this.dietsService.GetDietById<EditInputModel>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            inputModel.UserId = userId;

            await this.dietsService.UpdateDietAsync(id, inputModel);
            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.dietsService.DeleteDietByIdAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
