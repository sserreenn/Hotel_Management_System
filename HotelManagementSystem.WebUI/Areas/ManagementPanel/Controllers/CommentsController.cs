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
      public class CommentsController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Comments
            public ActionResult Index(int roomId) {
                  var comments = db.Comments.Where(x => x.RoomId == roomId).Include(c => c.Room);
                  ViewBag.VillaTitle = db.Rooms.Find(roomId).Title;
                  return View(comments.ToList());
            }

            // GET: ManagementPanel/Comments/Details/5
            public ActionResult Details(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Comment comment = db.Comments.Find(id);
                  if(comment == null) {
                        return HttpNotFound();
                  }
                  return View(comment);
            }

            // GET: ManagementPanel/Comments/Edit/5
            public ActionResult Edit(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Comment comment = db.Comments.Find(id);
                  if(comment == null) {
                        return HttpNotFound();
                  }
                  ViewBag.VillaId = new SelectList(db.Rooms, "RoomId", "Title", comment.RoomId);
                  return View(comment);
            }

            // POST: ManagementPanel/Comments/Edit/5 
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Comment model) {
                  if(ModelState.IsValid) {
                        var editComment = db.Comments.Find(model.CommentId);
                        editComment.CleaningReview = model.CleaningReview;
                        editComment.Email = model.Email;
                        editComment.FullName = model.FullName;
                        editComment.GeneralReview = model.GeneralReview;
                        editComment.IsActive = model.IsActive;
                        editComment.Message = model.Message;
                        editComment.PhoneNumber = model.PhoneNumber;
                        editComment.ServiceReview = model.ServiceReview;
                        editComment.RoomId = model.RoomId;
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
      }
}
