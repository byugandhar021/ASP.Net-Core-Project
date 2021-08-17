namespace Fitness.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Services.Data.Categories;
    using Fitness.Web.ViewModels;
    using Fitness.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index(string categorytype)
        {
            if (!string.IsNullOrWhiteSpace(categorytype))
            {
                var categories = new List<CategoryViewModel>();

                switch (categorytype)
                {
                    case "diet":
                        categories = this.categoryService.GetAllCategories<CategoryViewModel>().Where(s => s.CategoryType.ToString().ToLower() == "diet").ToList();
                        break;
                    case "exercise":
                        categories = this.categoryService.GetAllCategories<CategoryViewModel>().Where(s => s.CategoryType.ToString().ToLower() == "exercise").ToList();
                        break;
                    case "nutrition":
                        categories = this.categoryService.GetAllCategories<CategoryViewModel>().Where(s => s.CategoryType.ToString().ToLower() == "nutrition").ToList();
                        break;

                    default:
                        break;
                }

                var allViewModel = new AllViewModel
                {
                    Categories = categories,
                    CategoryType = categorytype,
                };
                return this.View(allViewModel);
            }

            return this.Error();
        }

        [HttpGet]
        public IActionResult Create(string categorytype)
        {
            var model = new CreateInputModel
            {
                CategoryType = categorytype,
            };
            return this.View("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string category, CreateInputModel model)
        {
            model.CategoryType = category;
            await this.categoryService.CreateCategoryAsync(model);
            return this.RedirectToAction("Create", "Diet", new { category = model.Name });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
