using MVC9909.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC9909.Controllers
{
    public class roomController : Controller
    {
        ABCDBContext myDB = new ABCDBContext();

        
        public ActionResult getRooms()
        {
            List<room> roomList = (from r in myDB.rooms select r).ToList();
            return View(roomList);
        }

        
        public ActionResult getRoom(int id)
        {
            room obj = (from r in myDB.rooms where r.roomId == id select r).FirstOrDefault();
            return View("Details", obj);
        }

      //هذه الميثود تعرض صفحة ادخال البيانات
        [HttpGet]
        public ActionResult insertRoom()
        {
            return View();
        }

        // هذه الميثود تستخدم لارسال البيانات المدخله 
        [HttpPost]
        public ActionResult insertRoom(room obj)
        {
            myDB.rooms.Add(obj);
            myDB.SaveChanges();
            return RedirectToAction("getRooms");
        }

        
        public ActionResult deleteRoom(int Id)
        {
            room obj = (from r in myDB.rooms 
                        where r.roomId == Id
                        select r).FirstOrDefault();
          
                myDB.rooms.Remove(obj);
                myDB.SaveChanges();
            
            return RedirectToAction("getRooms");
        }

        public ActionResult getDetails(int id)
        {
            room obj = (from s in myDB.rooms
                           where s.roomId == id
                           select s).FirstOrDefault();

            return View(obj);
        }


       //public ActionResult updateRoom(int roomId)
        //{
        //    room obj = (from r in myDB.rooms where r.roomId == roomId select r).FirstOrDefault();
        //    return View(obj);
        //}

      
        
        //public ActionResult updateRoom(room updatedRoom)
        //{
        //    room obj = (from r in myDB.rooms where r.roomId == updatedRoom.roomId select r).FirstOrDefault();
        //    if (obj != null)
        //    {
        //        obj.roomName = updatedRoom.roomName;
        //        obj.location = updatedRoom.location;
        //        obj.roomSize = updatedRoom.roomSize;
        //        obj.isAvailable = updatedRoom.isAvailable;
        //        myDB.SaveChanges();
        //    }
        //    return RedirectToAction("getRooms");
        //}

       
    }
}
