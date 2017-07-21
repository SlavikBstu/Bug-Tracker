using BugTracker.Models;
using BugTracker.Models.DBClasses;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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


            var user = UserManager.FindById(User.Identity.GetUserId());
            appl.us = user;
            appl.caption = app.Caption;
            appl.status = status_enum.initial;
            appl.type = app.Type;
            appl.priority = app.Priority;
            appl.annotation = app.Annotation;
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


        public ActionResult ListApplication()
        {
            return View();
        }
    }
}