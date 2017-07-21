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
    public class UserController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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
        public ActionResult CreateApplication(HttpPostedFileBase upload, ApplicationViewModel app)
        {
            Application appl = new Application();

            appl.us_id = User.Identity.GetUserId().ToString();
            appl.caption = app.Caption;
            appl.status = status_enum.initial;
            appl.type = app.Type;
            appl.priority = app.Priority;
            appl.annotation = app.Annotation;

            //var picturePath = "";

            //if (file != null/* && file.ContentLength > 0*/)
            //{
            //    string fileName = Path.GetFileName(file.FileName);
            //    picturePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
            //    var path = Path.Combine(Server.MapPath("~/ApplicationImages/" + fileName), picturePath);
            //    file.SaveAs(path);
            //    appl.picture = "~/ApplicationImages/" + fileName;
            //}
            //var count = Request.Files["upload"];

            //https://stackoverflow.com/questions/16255882/uploading-displaying-images-in-mvc-4

            if (upload != null)
            {
                // получаем имя файла 
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте 
                upload.SaveAs(Server.MapPath("~/ApplicationImages/" + fileName));
                appl.picture = "~/ApplicationImages/" + fileName;
            }

            if (ModelState.IsValid)
            {
                context.Applications.Add(appl);
                context.SaveChanges();
                return Redirect("/User/ListApplication");
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
            var dbApplications = context.Applications.Select(app => u.id_application == _id_application);
            var applications = dbApplications.Select(a => new ApplicationViewModel
            {
                Caption = a.caption,
                Annotation = a.annotation
            });

            return View(applications);
        }
    }
}