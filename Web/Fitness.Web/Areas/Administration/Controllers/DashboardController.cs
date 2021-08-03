//namespace Fitness.Web.Areas.Administration.Controllers
//{
//    using System.Threading.Tasks;

//    using Fitness.Data.Models;
//    using Fitness.Web.ViewModels.Administration.Dashboard;
//    using Microsoft.AspNetCore.Identity;
//    using Microsoft.AspNetCore.Mvc;

//    public class DashboardController : AdminController
//    {
//        private readonly RoleManager<IdentityRole> roleManager;
//        private readonly UserManager<ApplicationUser> userManager;

//        public DashboardController(
//            RoleManager<IdentityRole> roleManager,
//            UserManager<ApplicationUser> userManager)
//        {
//            this.roleManager = roleManager;
//            this.userManager = userManager;
//        }

//        public IActionResult Admin()
//        {
//            return this.View();
//        }

//        //private async Task CreateRolesandUsers()
//        //{
//        //    bool x = await this.roleManager.RoleExistsAsync("Admin");
//        //    if (!x)
//        //    {
//        //        var role = new IdentityRole();
//        //        role.Name = "Admin";
//        //        await this.roleManager.CreateAsync(role);

//        //        var user = new ApplicationUser();
//        //        user.UserName = "admin";
//        //        user.Email = "admin@abv.bg";

//        //        string userPWD = "admin@abv.bg";

//        //        IdentityResult chkUser = await this.userManager.CreateAsync(user, userPWD);

//        //        if (chkUser.Succeeded)
//        //        {
//        //            var result1 = await this.userManager.AddToRoleAsync(user, "Admin");
//        //        }
//        //    }

//        //    x = await this.roleManager.RoleExistsAsync("User");
//        //    if (!x)
//        //    {
//        //        var role = new IdentityRole();
//        //        role.Name = "User";
//        //        await this.roleManager.CreateAsync(role);
//        //    }
//        //}
//    }
//}
