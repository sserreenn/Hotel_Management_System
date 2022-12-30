using HotelManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.WebUI.Controllers {
      public class RoomController : Controller {
            HotelManagementContext db = new HotelManagementContext();
            // GET: Room
            public ActionResult Index() {
                  return View(db.Rooms.ToList());
            }

            public ActionResult RoomDetails(int? id) {
                  var model = db.Rooms.Find(id);
                  return View(model);
            }
      }
}