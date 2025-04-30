using MVC9909.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC9909.Controllers
{
    public class teacerController : Controller
    {

        ABCDBContext myDB = new ABCDBContext();
        public ActionResult getTeacher()
        {
            List<teacher> teacherList = new List<teacher>();

            teacherList = (from teacher in myDB.teachers select teacher).ToList();
            return View( teacherList);


        }

        //هذه الميثود تعرض صفحة ادخال البيانات
        [HttpGet]
        public ActionResult insertTeacher()
        {
            return View();
        }

        // هذه الميثود تستخدم لارسال البيانات المدخله 
        [HttpPost]
        public ActionResult insertTeacher(teacher teacher)
        {

            myDB.teachers.Add(teacher);
            myDB.SaveChanges();
            return RedirectToAction("getTeacher");
        }


        public ActionResult deleteTeacher(int id)
        {
            teacher obj = new teacher();
            obj = (from data in myDB.teachers
                   where data.teacherId == id
                   select data).FirstOrDefault();

            myDB.teachers.Remove(obj);
            myDB.SaveChanges();



            return RedirectToAction("getTeacher");
        }

        public ActionResult getDetails(int id)
        {

            teacher obj = new teacher();
            obj = (from data in myDB.teachers
                   where data.teacherId == id
                   select data).FirstOrDefault();
            return View("Details",obj);
        }
    }
}