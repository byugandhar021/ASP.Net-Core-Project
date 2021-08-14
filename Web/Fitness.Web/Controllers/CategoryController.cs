namespace Fitness.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness.Services.Data.Categories;
    using Fitness.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index(string category)
        {
            var name = ControllerContext.ActionDescriptor.EndpointMetadata;

            var allViewModel = new AllViewModel
            {
                Categories = this.categoryService.GetAllCategories<CategoryViewModel>(),
            };
            return this.View(allViewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            await this.categoryService.CreateCategoryAsync(name);
            return this.RedirectToAction("Create", "DietController");
        }
    }
}
