using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.WebUI.Areas.ManagementPanel.Models.ViewModels;
using HotelManagementSystem.WebUI.Models;

namespace HotelManagementSystem.WebUI.Areas.ManagementPanel.Controllers {
      [Authorize]
      public class PricesController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Prices
            public ActionResult Index(int roomId) {
                  var prices = db.Prices.Where(x => x.RoomId == roomId).Include(p => p.Room).OrderBy(a => a.AccommodationBeginDate);
                  ViewBag.Room = roomId;
                  ViewBag.RoomName = db.Rooms.Find(roomId).Title;
                  return View(prices.ToList());
            }

            // GET: ManagementPanel/Prices/Create
            public ActionResult Create(int roomId) {
                  ViewBag.Room = roomId;
                  ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Title");
                  return View();
            }

            // POST: ManagementPanel/Prices/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Price price) {
                  if(ModelState.IsValid) {
                        price.IsActive = true;
                        price.RegisterDate = DateTime.Now;
                        db.Prices.Add(price);
                        db.SaveChanges();
                        return RedirectToAction("Index", new { roomId = price.RoomId });
                  }
                  ViewBag.Room = price.RoomId;
                  ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Title", price.RoomId);
                  return View(price);
            }

            // GET: ManagementPanel/Prices/Edit/5
            public ActionResult Edit(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Price price = db.Prices.Find(id);
                  if(price == null) {
                        return HttpNotFound();
                  }
                  ViewBag.VillaId = new SelectList(db.Rooms, "RoomId", "Title", price.RoomId);
                  return View(price);
            }

            // POST: ManagementPanel/Prices/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Price model) {
                  if(ModelState.IsValid) {
                        var editPrice = db.Prices.Find(model.PriceId);
                        editPrice.AccommodationBeginDate = model.AccommodationBeginDate;
                        editPrice.AccommodationEndDate = model.AccommodationEndDate;
                        editPrice.IsActive = model.IsActive;
                        editPrice.MinAccommodationDay = model.MinAccommodationDay;
                        editPrice.PricePerWeek = model.PricePerWeek;
                        editPrice.RoomId = model.RoomId;
                        editPrice.CurrencyType = model.CurrencyType;
                        db.SaveChanges();
                        return RedirectToAction("Index", new { roomId = model.RoomId });
                  }
                  ViewBag.VillaId = new SelectList(db.Rooms, "RoomId", "Title", model.RoomId);
                  return View(model);
            }


            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }

            [HttpPost]
            public JsonResult PricesforCalendar(int roomId) {
                  Random random = new Random();
                  var prices = db.Prices.Where(x => x.RoomId == roomId).ToList();
                  var priceData = new List<PriceCalendarViewModel>();
                  foreach(var item in prices) {
                        string text = "Haftalık ➤ " + item.PricePerWeek + " ₺";
                        priceData.Add(new PriceCalendarViewModel {
                              title = text,
                              start = item.AccommodationBeginDate.Value.Year + "-" + item.AccommodationBeginDate.Value.Month + "-" + item.AccommodationBeginDate.Value.Day,
                              end = item.AccommodationEndDate.Value.Year + "-" + item.AccommodationEndDate.Value.Month + "-" + item.AccommodationEndDate.Value.Day,
                              color = String.Format("#{0:X6}", random.Next(0x1000000)).ToString()
                        });
                  }
                  return Json(priceData, JsonRequestBehavior.AllowGet);
            }

            [ChildActionOnly]
            public ActionResult _Calendar(int roomId) {
                  Random random = new Random();
                  var prices = db.Prices.Where(x => x.RoomId == roomId).ToList();
                  var priceData = new List<PriceCalendarViewModel>();
                  foreach(var item in prices) {
                        string text = "Haftalık ➤ " + item.PricePerWeek + " ₺";
                        priceData.Add(new PriceCalendarViewModel {
                              title = text,
                              start = item.AccommodationBeginDate.Value.ToString("yyyy") + "-" + item.AccommodationBeginDate.Value.ToString("MM") + "-" + item.AccommodationBeginDate.Value.ToString("dd"),
                              end = item.AccommodationEndDate.Value.ToString("yyyy") + "-" + item.AccommodationEndDate.Value.ToString("MM") + "-" + item.AccommodationEndDate.Value.ToString("dd"),
                              color = String.Format("#{0:X6}", random.Next(0x1000000)).ToString()
                        });
                  }

                  return PartialView("_Calendar", priceData);
            }


      }
}
