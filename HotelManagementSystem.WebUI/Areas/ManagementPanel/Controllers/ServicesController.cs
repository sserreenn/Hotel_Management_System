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
      public class ServicesController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Services
            public ActionResult Index() {
                  return View(db.Services.ToList());
            }
             

            // GET: ManagementPanel/Services/Create
            public ActionResult Create() {
                  return View();
            }

            // POST: ManagementPanel/Services/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Service service, HttpPostedFileBase img) {
                  if(ModelState.IsValid) {
                        if(img != null)
                              service.ImageURL = UploadHelper.SaveImage(img);
                        service.IsActive = true;
                        service.RegisterDate = DateTime.Now;
                        db.Services.Add(service);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }

                  return View(service);
            }

            // GET: ManagementPanel/Services/Edit/5
            public ActionResult Edit(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Service service = db.Services.Find(id);
                  if(service == null) {
                        return HttpNotFound();
                  }
                  return View(service);
            }

            // POST: ManagementPanel/Services/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Service service, HttpPostedFileBase img) {
                  if(ModelState.IsValid) {
                        var editService = db.Services.Find(service.ServiceId);
                        if(img != null) {
                              UploadHelper.DeleteFileOrImage(editService.ImageURL);
                              editService.ImageURL = UploadHelper.SaveImage(img);
                        }
                        editService.IsActive = service.IsActive;
                        editService.Name = service.Name;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }
                  return View(service);
            } 
            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }
      }
}
