namespace Fitness.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class GymController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
