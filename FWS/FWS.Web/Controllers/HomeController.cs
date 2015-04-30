using System;
using System.Web.Mvc;
using FWS.Ent.Crew;
using FWS.Neg.Crew;
using Microsoft.AspNet.Identity;

namespace FWS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Main()
        {

            try
            {
                var result = new nUserInfo().ListarRegistrosComFiltro(new eUserInfo{memberId =  User.Identity.GetUserId()});
                Session["User"] = result;

                ViewBag.Message = "Main";
                return View(result);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}