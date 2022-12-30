using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.WebUI.Models;

namespace HotelManagementSystem.WebUI.Areas.ManagementPanel.Controllers {
      [Authorize]
      public class UsersController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Users
            public ActionResult Index() {
                  return View(db.Users.ToList());
            }

            // GET: ManagementPanel/Users/Create
            public ActionResult Create() {
                  return View();
            }

            // POST: ManagementPanel/Users/Create 
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(User user) {
                  if(ModelState.IsValid) {
                        user.IsActive = true;
                        user.RegisterDate = DateTime.Now;
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }

                  return View(user);
            }

            // GET: ManagementPanel/Users/Edit/5
            public ActionResult Edit(short? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  User user = db.Users.Find(id);
                  if(user == null) {
                        return HttpNotFound();
                  }
                  return View(user);
            }

            // POST: ManagementPanel/Users/Edit/5 
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(User user) {
                  if(ModelState.IsValid) {
                        var editUser = db.Users.Find(user.UserId);
                        editUser.Email = user.Email;
                        editUser.FullName = user.FullName;
                        editUser.IsActive = user.IsActive;
                        editUser.Password = user.Password;
                        editUser.PhoneNumber = user.PhoneNumber;
                        editUser.Address = user.Address;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }
                  return View(user);
            }


            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }
      }
}
