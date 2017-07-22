using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.IsInRole("admin"))
            {
                return RedirectToAction("Admin", "Account");
            }
            if (User.IsInRole("user"))
            {
                return RedirectToAction("ListApplication", "Application");
            }
            return View();
        }
    }
}