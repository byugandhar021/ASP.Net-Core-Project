namespace Fitness.Web.Areas.Administration.Controllers
{
    using Fitness.Common;
    using Fitness.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Admin")]
    public class AdministrationController : BaseController
    {
    }
}
