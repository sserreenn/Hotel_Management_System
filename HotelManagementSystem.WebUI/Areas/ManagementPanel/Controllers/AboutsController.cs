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
      [ValidateInput(false)]
      public class AboutsController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Abouts
            public ActionResult Index() {
                  return View(db.Abouts.FirstOrDefault());
            }
             

            // GET: ManagementPanel/Abouts/Edit/5
            public ActionResult Edit(byte? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  About about = db.Abouts.Find(id);
                  if(about == null) {
                        return HttpNotFound();
                  }
                  return View(about);
            }

            // POST: ManagementPanel/Abouts/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(About about, HttpPostedFileBase img) {
                  if(ModelState.IsValid) {
                        var editAbout = db.Abouts.Find(about.AboutId);
                        if(img != null) {
                              UploadHelper.DeleteFileOrImage(editAbout.ImageURL);
                              editAbout.ImageURL = UploadHelper.SaveImage(img);
                        }
                        editAbout.Title = about.Title;
                        editAbout.Description = about.Description;

                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }
                  return View(about);
            }
             
            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }
      }
}
