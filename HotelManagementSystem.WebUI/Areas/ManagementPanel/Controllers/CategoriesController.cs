using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.WebUI.Areas.ManagementPanel.Helpers;
using HotelManagementSystem.WebUI.Models;

namespace HotelManagementSystem.WebUI.Areas.ManagementPanel.Controllers {
      [Authorize]
      public class CategoriesController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Categories
            public ActionResult Index() {
                  return View(db.Categories.ToList());
            }
             

            // GET: ManagementPanel/Categories/Create
            public ActionResult Create() {
                  return View();
            }

            // POST: ManagementPanel/Categories/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Category category) {
                  if(ModelState.IsValid) {
                        category.RegisterDate = DateTime.Now;
                        category.IsActive = true;
                        db.Categories.Add(category);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }

                  return View(category);
            }

            // GET: ManagementPanel/Categories/Edit/5
            public ActionResult Edit(short? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Category category = db.Categories.Find(id);
                  if(category == null) {
                        return HttpNotFound();
                  }
                  return View(category);
            }

            // POST: ManagementPanel/Categories/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Category category) {
                  if(ModelState.IsValid) {
                        var editCategory = db.Categories.Find(category.CategoryId);
                        editCategory.IsActive = category.IsActive;
                        editCategory.Name = category.Name;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }
                  return View(category);
            }
             
            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }
      }
}
