using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCSite.Controllers
{
    public class CuisineController : Controller
    {
        [HttpPost]
        public ActionResult Search(string name = "french")
        {
            var message = Server.HtmlEncode(name);

            return Content(message);
            //return RedirectPermanent("http://microsoft.com"); //Redirects permanently
            //return RedirectToAction("Index", "Home", new { name = name }); 
            //return RedirectToRoute("Default", new { controller = "Home", action = "About" });
            //return Json(new { Message = message, Name = "Bret" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return Content("Search!");
        }
    }
}