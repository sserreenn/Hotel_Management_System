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
      [ValidateInput(false)]
      public class FAQsController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/FAQs
            public ActionResult Index() {
                  return View(db.FAQs.ToList());
            }

            // GET: ManagementPanel/FAQs/Details/5
            public ActionResult Details(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  FAQ fAQ = db.FAQs.Find(id);
                  if(fAQ == null) {
                        return HttpNotFound();
                  }
                  return View(fAQ);
            }

            // GET: ManagementPanel/FAQs/Create
            public ActionResult Create() {
                  return View();
            }

            // POST: ManagementPanel/FAQs/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(FAQ fAQ) {
                  if(ModelState.IsValid) {
                        fAQ.RegisterDate = DateTime.Now;
                        fAQ.IsActive = true;
                        db.FAQs.Add(fAQ);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }

                  return View(fAQ);
            }

            // GET: ManagementPanel/FAQs/Edit/5
            public ActionResult Edit(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  FAQ fAQ = db.FAQs.Find(id);
                  if(fAQ == null) {
                        return HttpNotFound();
                  }
                  return View(fAQ);
            }

            // POST: ManagementPanel/FAQs/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(FAQ model) {
                  if(ModelState.IsValid) {
                        var editFaq = db.FAQs.Find(model.FAQId);
                        editFaq.IsActive = model.IsActive;
                        editFaq.Answer = model.Answer;
                        editFaq.Question = model.Question;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }
                  return View(model);
            }

            //// GET: ManagementPanel/FAQs/Delete/5
            //public ActionResult Delete(int? id) {
            //      if(id == null) {
            //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //      }
            //      FAQ fAQ = db.FAQs.Find(id);
            //      if(fAQ == null) {
            //            return HttpNotFound();
            //      }
            //      return View(fAQ);
            //}

            //// POST: ManagementPanel/FAQs/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public ActionResult DeleteConfirmed(int id) {
            //      FAQ fAQ = db.FAQs.Find(id);
            //      db.FAQs.Remove(fAQ);
            //      db.SaveChanges();
            //      return RedirectToAction("Index");
            //}

            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }
      }
}
