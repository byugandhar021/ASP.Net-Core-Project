namespace Fitness.Web.Controllers
{
    using Fitness.Services.Data.Categories;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
