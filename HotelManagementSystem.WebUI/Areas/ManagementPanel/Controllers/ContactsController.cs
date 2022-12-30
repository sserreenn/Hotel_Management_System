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
      public class ContactsController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Contacts
            public ActionResult Index() {
                  return View(db.Contacts.FirstOrDefault());
            }


            // GET: ManagementPanel/Contacts/Edit/5
            public ActionResult Edit(byte? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Contact contact = db.Contacts.Find(id);
                  if(contact == null) {
                        return HttpNotFound();
                  }
                  return View(contact);
            }

            // POST: ManagementPanel/Contacts/Edit/5 
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Contact contact, HttpPostedFileBase img) {
                  if(ModelState.IsValid) {
                        var editContact = db.Contacts.Find(contact.ContactId);
                        if(img != null) {
                              UploadHelper.DeleteFileOrImage(editContact.ImageURL);
                              editContact.ImageURL = UploadHelper.SaveImage(img);
                        }
                        editContact.Address = contact.Address;
                        editContact.Email = contact.Email;
                        editContact.Description = contact.Description;
                        editContact.Map = contact.Map;
                        editContact.PhoneNumber = contact.PhoneNumber;
                        editContact.Title = contact.Title;
                        editContact.ZipCode = contact.ZipCode;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }
                  return View(contact);
            }


            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }
      }
}
