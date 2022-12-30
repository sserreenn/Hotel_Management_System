using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.WebUI.Areas.ManagementPanel.Helpers;
using HotelManagementSystem.WebUI.Areas.ManagementPanel.Models.ViewModels;
using HotelManagementSystem.WebUI.Models;
using PagedList;

namespace HotelManagementSystem.WebUI.Areas.ManagementPanel.Controllers {
      [Authorize]
      [ValidateInput(false)]
      public class RoomsController : Controller {
            private HotelManagementContext db = new HotelManagementContext();

            // GET: ManagementPanel/Rooms
            public ActionResult Index(int? page, string search = null) {
                  var rooms = db.Rooms.OrderByDescending(x => x.RegisterDate).ToList();
                  ViewBag.SearchText = search;
                  if(!string.IsNullOrEmpty(search)) {
                        rooms = rooms.Where(c => c.Title.ToLower().Contains(search.ToLower())).ToList();
                  }
                  int pageSize = 9;
                  int pageNumber = (page ?? 1);
                  return View(rooms.ToPagedList(pageNumber, pageSize));
            }

            // GET: ManagementPanel/Rooms/Details/5
            public ActionResult Details(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Room room = db.Rooms.Find(id);
                  if(room == null) {
                        return HttpNotFound();
                  }
                  return View(room);
            }

            // GET: ManagementPanel/Rooms/Create
            public ActionResult Create() {

                  return View();
            }

            // POST: ManagementPanel/Rooms/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(RoomViewModel model, HttpPostedFileBase img, List<HttpPostedFileBase> imgList, List<short> categoryList, List<int> amenityList, List<int> serviceList) {
                  if(ModelState.IsValid) {
                        Room room = new Room {
                              BathCapacity = model.BathCapacity,
                              BedCapacity = model.BedCapacity,
                              BriefDescription = model.BriefDescription,
                              Characteristic = model.Characteristic,
                              Code = model.Code,
                              CurrencyType = model.CurrencyType,
                              IsActive = true,
                              MaxPrice = model.MaxPrice,
                              MinPrice = model.MinPrice,
                              OrderNo = model.OrderNo,
                              PersonCapacity = model.PersonCapacity,
                              RegisterDate = DateTime.Now,
                              Size = model.Size,
                              Title = model.Title,
                        };
                        if(img != null)
                              room.ImageURL = UploadHelper.SaveImage(img);
                        db.Rooms.Add(room);
                        db.SaveChanges();

                        RoomDetail detail = new RoomDetail {
                              AverageReview = 0,
                              ReviewCounter = 0,
                              Description = model.Description,
                              Rules = model.Rules,
                              RoomId = room.RoomId
                        };
                        db.RoomDetails.Add(detail);
                        db.SaveChanges();

                        foreach(var item in imgList) {
                              if(item != null) {
                                    var imageObj = new Image { ImageURL = UploadHelper.SaveImage(item), RoomId = room.RoomId };
                                    db.Images.Add(imageObj);
                                    db.SaveChanges();
                              }
                        }

                        foreach(var item in categoryList) {
                              db.RoomByCategories.Add(new RoomByCategory { CategoryId = item, RoomId = room.RoomId });
                              db.SaveChanges();
                        }

                        foreach(var item in amenityList) {
                              db.AmenityByRooms.Add(new AmenityByRoom { AmenityId = item, RoomId = room.RoomId });
                              db.SaveChanges();
                        }
                        foreach(var item in serviceList) {
                              db.ServiceByRooms.Add(new ServiceByRoom { ServiceId = item, RoomId = room.RoomId });
                              db.SaveChanges();
                        }

                        return RedirectToAction("Index");
                  }

                  return View(model);
            }

            // GET: ManagementPanel/Rooms/Edit/5
            public ActionResult Edit(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Room room = db.Rooms.Find(id);
                  if(room == null) {
                        return HttpNotFound();
                  }

                  RoomViewModel model = new RoomViewModel {
                        BathCapacity = room.BathCapacity,
                        BedCapacity = room.BedCapacity,
                        BriefDescription = room.BriefDescription,
                        Characteristic = room.Characteristic,
                        Code = room.Code,
                        CurrencyType = room.CurrencyType,
                        Description = room.RoomDetail.Description,
                        ImageURL = room.ImageURL,
                        IsActive = room.IsActive,
                        MaxPrice = room.MaxPrice,
                        MinPrice = room.MinPrice,
                        OrderNo = room.OrderNo,
                        PersonCapacity = room.PersonCapacity,
                        RoomId = room.RoomId,
                        RegisterDate = room.RegisterDate,
                        Rules = room.RoomDetail.Rules,
                        Size = room.Size,
                        Title = room.Title
                  };

                  return View(model);
            }

            // POST: ManagementPanel/Rooms/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(RoomViewModel model, HttpPostedFileBase img, List<HttpPostedFileBase> imgList, List<short> categoryList, List<int> amenityList, List<int> serviceList) {
                  if(ModelState.IsValid) {
                        Room editRoom = db.Rooms.Find(model.RoomId);
                        if(img != null) {
                              UploadHelper.DeleteFileOrImage(editRoom.ImageURL);
                              editRoom.ImageURL = UploadHelper.SaveImage(img);
                        }
                        editRoom.BathCapacity = model.BathCapacity;
                        editRoom.BedCapacity = model.BedCapacity;
                        editRoom.BriefDescription = model.BriefDescription;
                        editRoom.Characteristic = model.Characteristic;
                        editRoom.Code = model.Code;
                        editRoom.CurrencyType = model.CurrencyType;
                        editRoom.IsActive = model.IsActive;
                        editRoom.MaxPrice = model.MaxPrice;
                        editRoom.MinPrice = model.MinPrice;
                        editRoom.OrderNo = model.OrderNo;
                        editRoom.PersonCapacity = model.PersonCapacity;
                        editRoom.Size = model.Size;
                        editRoom.Title = model.Title;

                        RoomDetail editDetail = db.RoomDetails.Find(model.RoomId);
                        editDetail.Description = model.Description;
                        editDetail.Rules = model.Rules;

                        foreach(var item in imgList) {
                              if(item != null) {
                                    var imgObj = new Image { ImageURL = UploadHelper.SaveImage(item), RoomId = model.RoomId };
                                    db.Images.Add(imgObj);
                                    db.SaveChanges();
                              }
                        }

                        //Update categories
                        if(categoryList != null && categoryList.Count != 0) {
                              foreach(var item in categoryList) {
                                    bool isCategoryExist = false;
                                    foreach(var cat in editRoom.RoomByCategories) {
                                          if(item == cat.RoomByCategoryId) {
                                                isCategoryExist = true;
                                          }
                                    }
                                    if(!isCategoryExist) {
                                          db.RoomByCategories.Add(new RoomByCategory { RoomId = model.RoomId, CategoryId = item });
                                          db.SaveChanges();
                                    }
                              }

                              List<RoomByCategory> categList = editRoom.RoomByCategories.ToList();
                              foreach(var cat in categList) {
                                    bool isCatExist = false;
                                    foreach(var item in categoryList) {
                                          if(cat.CategoryId == item) {
                                                isCatExist = true;
                                          }
                                    }
                                    if(!isCatExist) {
                                          db.RoomByCategories.Remove(cat);
                                          db.SaveChanges();
                                    }
                              }
                        }

                        //Update amenities
                        if(amenityList != null && amenityList.Count != 0) {
                              foreach(var item in amenityList) {
                                    bool isAmenityExist = false;
                                    foreach(var amt in editRoom.AmenityByRooms) {
                                          if(item == amt.AmenityByRoomId) {
                                                isAmenityExist = true;
                                          }
                                    }
                                    if(!isAmenityExist) {
                                          db.AmenityByRooms.Add(new AmenityByRoom { RoomId = model.RoomId, AmenityId = item });
                                          db.SaveChanges();
                                    }
                              }

                              List<AmenityByRoom> amtList = editRoom.AmenityByRooms.ToList();
                              foreach(var amt in amtList) {
                                    bool isAmtExist = false;
                                    foreach(var item in amenityList) {
                                          if(amt.AmenityId == item) {
                                                isAmtExist = true;
                                          }
                                    }
                                    if(!isAmtExist) {
                                          db.AmenityByRooms.Remove(amt);
                                          db.SaveChanges();
                                    }
                              }
                        }

                        //Update services
                        if(serviceList != null && serviceList.Count != 0) {
                              foreach(var item in serviceList) {
                                    bool isServiceExist = false;
                                    foreach(var serv in editRoom.ServiceByRooms) {
                                          if(item == serv.ServiceByRoomId) {
                                                isServiceExist = true;
                                          }
                                    }
                                    if(!isServiceExist) {
                                          db.ServiceByRooms.Add(new ServiceByRoom { RoomId = model.RoomId, ServiceId = item });
                                          db.SaveChanges();
                                    }
                              }

                              List<ServiceByRoom> servList = editRoom.ServiceByRooms.ToList();
                              foreach(var serv in servList) {
                                    bool isServiceExist = false;
                                    foreach(var item in serviceList) {
                                          if(item == serv.ServiceId) {
                                                isServiceExist = true;
                                          }
                                    }
                                    if(!isServiceExist) {
                                          db.ServiceByRooms.Remove(serv);
                                          db.SaveChanges();
                                    }
                              }
                        }


                        db.SaveChanges();
                        return RedirectToAction("Index");
                  }

                  return View(model);
            }

            // GET: ManagementPanel/Rooms/Delete/5
            public ActionResult Delete(int? id) {
                  if(id == null) {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Room room = db.Rooms.Find(id);
                  if(room == null) {
                        return HttpNotFound();
                  }
                  return View(room);
            }

            // POST: ManagementPanel/Rooms/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id) {
                  Room room = db.Rooms.Find(id);

                  db.Prices.RemoveRange(room.Prices);
                  db.Comments.RemoveRange(room.Comments);
                  db.Images.RemoveRange(room.Images);
                  db.AmenityByRooms.RemoveRange(room.AmenityByRooms);
                  db.ServiceByRooms.RemoveRange(room.ServiceByRooms);
                  db.RoomByCategories.RemoveRange(room.RoomByCategories);
                  db.RoomDetails.Remove(room.RoomDetail);
                  db.SaveChanges();
                  db.Rooms.Remove(room);
                  db.SaveChanges();
                  return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing) {
                  if(disposing) {
                        db.Dispose();
                  }
                  base.Dispose(disposing);
            }

            [ChildActionOnly]
            public ActionResult _RoomImages(int roomId) {
                  var model = db.Images.Where(x => x.RoomId == roomId).ToList();
                  return PartialView("_RoomImages", model);
            }

            [HttpPost]
            public JsonResult DeleteImg(int imgId) {
                  var img = db.Images.Find(imgId);
                  UploadHelper.DeleteFileOrImage(img.ImageURL);
                  db.Images.Remove(img);
                  db.SaveChanges();
                  return Json("Done");
            }

            [ChildActionOnly]
            public ActionResult _RoomCategories(int? roomId = null) {
                  TempData["CategoryIdList"] = db.Categories.ToList();
                  if(roomId != null) {
                        var model = db.RoomByCategories.Where(x => x.RoomId == roomId).ToList();
                        return PartialView("_RoomCategories", model);
                  }
                  return PartialView("_RoomCategories");
            }

            [ChildActionOnly]
            public ActionResult _RoomServices(int? roomId = null) {
                  TempData["ServiceIdList"] = db.Services.ToList();
                  if(roomId != null) {
                        var model = db.ServiceByRooms.Where(x => x.RoomId == roomId).ToList();
                        return PartialView("_RoomServices", model);
                  }
                  return PartialView("_RoomServices");
            }

            [ChildActionOnly]
            public ActionResult _RoomAmenities(int? roomId) {
                  TempData["AmenityIdList"] = db.Amenities.ToList();
                  if(roomId != null) {
                        var model = db.AmenityByRooms.Where(x => x.RoomId == roomId).ToList();
                        return PartialView("_RoomAmenities", model);
                  }
                  return PartialView("_RoomAmenities");
            }
      }
}
