using HotelManagementSystem.WebUI.Areas.ManagementPanel.Models.ViewModels;
using HotelManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelManagementSystem.WebUI.Areas.ManagementPanel.Controllers {
      public class AccountController : Controller {
            HotelManagementContext db = new HotelManagementContext();

            [AllowAnonymous]
            public ActionResult Login() {
                  return View();
            }

            [AllowAnonymous]
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(LoginViewModel model) {
                  if(ModelState.IsValid) {
                        var user = db.Users.FirstOrDefault(c => c.Email.Equals(model.Email) && c.Password.Equals(model.Password));

                        if(user != null) {
                              FormsAuthentication.SetAuthCookie(user.FullName, false);
                              return RedirectToAction("Index", "Dashboard");
                        }
                  }
                  ModelState.AddModelError("", "Email ya da şifre yanlış.");
                  return View(model);
            }

            [HttpGet]
            public ActionResult Logout() {
                  FormsAuthentication.SignOut();
                  return RedirectToAction("Login", "Account");
            }

      }
}