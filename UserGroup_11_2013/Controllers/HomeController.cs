using System.IdentityModel.Services;
using System.Security.Claims;
using System.Security.Permissions;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Authorization.Mvc;

namespace UserGroup.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            var ca = new ClaimsAuthorizationManager();
            ClaimsPrincipalPermission.CheckAccess("home/about", "view");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ClaimsPrincipalPermission(SecurityAction.Demand, Resource ="home/contact", Operation = "view")]
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}