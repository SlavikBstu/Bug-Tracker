using BugTracker.Models;
using BugTracker.Models.DBClasses;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;

namespace BugTracker.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private static List<string> imageMimeTypes = new List<string>()
        {
            "image/gif",
            "image/jpeg",
            "image/png",
            "image/tiff"
        };
        
        ApplicationDbContext context = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationController()
        {
        }

        public ApplicationController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public ActionResult CreateApplication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateApplication(IEnumerable<HttpPostedFileBase> uploadImages, ApplicationViewModel app)
        {
            Application appl = new Application();
            appl.us_id = User.Identity.GetUserId().ToString();
            appl.caption = app.Caption;
            appl.status = status_enum.initial;
            appl.type = app.Type;
            appl.priority = app.Priority;
            appl.annotation = app.Annotation;

            string imgName = string.Empty, imgPath = imgName;
            foreach (var img in uploadImages)
            {
                if (img != null && imageMimeTypes.Contains(img.ContentType) && img.ContentLength > 0)
                {
                    imgName = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Path.Combine(Server.MapPath("~/ApplicationImages"), imgName));
                    imgPath = "~/ApplicationImages/" + imgName;
                    if (appl.picture == null)
                        appl.picture = imgPath;
                    else
                        appl.picture += "|" + imgPath;
                }
            }

            if (ModelState.IsValid)
            {
                context.Applications.Add(appl);
                context.SaveChanges();
                return RedirectToAction("ListApplication", "Application");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ListApplication()
        {
            var dbApplications = context.Applications.ToList();
            var applications = dbApplications.Select(a => new ApplicationViewModel
            {
                Caption = a.caption,
                Annotation = a.annotation
            });

            return View(applications);
        }

        [HttpGet]
        public ActionResult DetailsApplication(string _id_application)
        {
            //var dbApplications = context.Applications.Select(app => u.id_application == _id_application);
            //var applications = dbApplications.Select(a => new ApplicationViewModel
            //{
            //    Caption = a.caption,
            //    Annotation = a.annotation
            //});applications

            return View();
        }
    }
}