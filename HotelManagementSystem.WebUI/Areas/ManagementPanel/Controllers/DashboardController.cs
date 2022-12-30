using HotelManagementSystem.WebUI.Areas.ManagementPanel.Models.ViewModels;
using HotelManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.WebUI.Areas.ManagementPanel.Controllers {
      [Authorize]
      public class DashboardController : Controller {
            HotelManagementContext db = new HotelManagementContext();
            // GET: ManagementPanel/Dashboard
            public ActionResult Index() {
                  DashboardViewModel model = new DashboardViewModel();
                  model.RoomList = db.Rooms.OrderByDescending(x => x.RegisterDate).Take(3).ToList();
                  model.CategoryCount = db.Categories.Count();
                  model.RoomCount = db.Rooms.Count();
                  model.UserCount = db.Users.Count();
                  model.ContactMessageCount = db.ContactMessages.Count();
                  return View(model);
            }
      }
}