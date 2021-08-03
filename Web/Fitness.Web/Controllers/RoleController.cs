namespace Fitness.Web.Controllers
{
    using Fitness.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    public class RoleController : BaseController
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create() => this.View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string roleName)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.roleManager.CreateAsync(new ApplicationRole(roleName));
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index");
                }
                else
                {
                    this.Errors(result);
                }
            }

            return this.View();
        }

        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await this.roleManager.FindByNameAsync(roleId);

            if (role != null)
            {
                var result = await this.roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index");
                }
                else
                {
                    this.Errors(result);
                }
            }
            else
            {
                this.ModelState.AddModelError("krkrkrkrkrrkrkrkrkkr", "No role found");
            }

            return this.View("Index", this.roleManager.Roles);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                this.ModelState.AddModelError("error in RoLE kontroler", error.Description);
            }
        }
    }
}
