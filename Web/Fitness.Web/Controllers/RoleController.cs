namespace Fitness.Web.Controllers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using Fitness.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RoleController : BaseController
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = this.roleManager.Roles;
            return this.View(roles);
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

        public async Task<IActionResult> Update(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);
            var members = new List<ApplicationUser>();
            var nonMembers = new List<ApplicationUser>();

            foreach (var user in this.userManager.Users)
            {
                var list = await this.userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            return this.View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (this.ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    var user = await this.userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await this.userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            this.Errors(result);
                        }
                    }
                }

                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    var user = await this.userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await this.userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            this.Errors(result);
                        }
                    }
                }
            }

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                return await this.Update(model.RoleId);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);

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
