using HotelManagementSystem.WebUI.Models;
using HotelManagementSystem.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.WebUI.Controllers {
      public class HomeController : Controller {
            HotelManagementContext db = new HotelManagementContext();
            // GET: Home
            public ActionResult Index() {
                  MainPageViewModel model = new MainPageViewModel();
                  model.RoomList = db.Rooms.Take(6).ToList();
                  return View(model);
            }

            public ActionResult AboutUs() {
                  return View(db.Abouts.FirstOrDefault());
            }

            public ActionResult Contact() {
                  return View(db.Contacts.FirstOrDefault());
            }

            [HttpPost]
            public ActionResult Contact(string fullName, string phone, string email, string subject, string message) {
                  try {
                        ContactMessage model = new ContactMessage {
                              Email = email,
                              FullName = fullName,
                              Message = message,
                              Phone = phone,
                              Subject = subject,
                              RegisterDate = DateTime.Now,
                        };
                        db.ContactMessages.Add(model);
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Mesajınız gönderildi.";
                  }
                  catch(Exception ex) {
                        ViewBag.SuccessMessage = "Bir sorun oluştu.";
                        return RedirectToAction("Contact");
                  }

                  return RedirectToAction("Contact");
            }


            public ActionResult FAQ() {
                  return View(db.FAQs.Where(x => x.IsActive == true).ToList());
            }
      }
}