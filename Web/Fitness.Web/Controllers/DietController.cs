namespace Fitness.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DietController : BaseController
    {
        public IActionResult AllByCategory()
        {
            return View();
        }
    }
}
