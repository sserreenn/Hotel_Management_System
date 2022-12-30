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
      public class ContactMessagesController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/ContactMessages
            public ActionResult Index() {
                  return View(db.ContactMessages.OrderByDescending(x => x.RegisterDate).ToList());
            }

            // GET: ManagementPanel/ContactMessages/Details/5
            public ActionResult Details(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  ContactMessage contactMessage = db.ContactMessages.Find(id);
                  if(contactMessage == null) {
                        return HttpNotFound();
                  }
                  return View(contactMessage);
            }

            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }
      }
}
