namespace Fitness.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    public class NutritionController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
