namespace Fitness.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness.Services.Data.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return this.View(this.categoryService.GetAllCategory());
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
