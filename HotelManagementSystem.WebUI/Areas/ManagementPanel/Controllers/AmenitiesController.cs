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
      public class AmenitiesController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Amenities
            public ActionResult Index() {
                  return View(db.Amenities.ToList());
            }
 
            // GET: ManagementPanel/Amenities/Create
            public ActionResult Create() {
                  return View();
            }

            // POST: ManagementPanel/Amenities/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Amenity amenity, HttpPostedFileBase img) {
                  if(ModelState.IsValid) {
                        if(img != null)
                              amenity.ImageURL = UploadHelper.SaveImage(img);
                        amenity.IsActive = true;
                        amenity.RegisterDate = DateTime.Now;
                        db.Amenities.Add(amenity);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }

                  return View(amenity);
            }

            // GET: ManagementPanel/Amenities/Edit/5
            public ActionResult Edit(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Amenity amenity = db.Amenities.Find(id);
                  if(amenity == null) {
                        return HttpNotFound();
                  }
                  return View(amenity);
            }

            // POST: ManagementPanel/Amenities/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Amenity amenity, HttpPostedFileBase img) {
                  if(ModelState.IsValid) {
                        var editAmenity = db.Amenities.Find(amenity.AmenityId);
                        if(img != null) {
                              UploadHelper.DeleteFileOrImage(editAmenity.ImageURL);
                              editAmenity.ImageURL = UploadHelper.SaveImage(img);
                        }
                        editAmenity.IsActive = amenity.IsActive;
                        editAmenity.Name = amenity.Name;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }
                  return View(amenity);
            }
             
            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }
      }
}
