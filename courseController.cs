using MVC9909.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC9909.Controllers
{
    public class courseController : Controller
    {
        ABCDBContext myDB = new ABCDBContext();

        public ActionResult getCourses()
        {
            List<course> courseList = new List<course>();
            courseList = (from obj in myDB.courses select obj).ToList();
            return View(courseList);
        }

   
        public ActionResult getCourse(int id)
        {
            course obj = (from xyz in myDB.courses where xyz.courseId == id select xyz).FirstOrDefault();
            return View("Details", obj);
        }

        //هذه الميثود تعرض صفحة ادخال البيانات
        [HttpGet]
        public ActionResult insertCourse()
        {
            return View();
        }


        // هذه الميثود تستخدم لارسال البيانات المدخله 
        [HttpPost]
        public ActionResult insertCourse(course obj)
        {
            myDB.courses.Add(obj);
            myDB.SaveChanges();
            return RedirectToAction("getCourses");
        }

        
        public ActionResult deleteCourse(int id)
        {
            course obj = new course();
            obj = (from data in myDB.courses
                   where data.courseId == id
                   select data).FirstOrDefault();

            myDB.courses.Remove(obj);
            myDB.SaveChanges();



            return RedirectToAction("getCourses");
        }

        public ActionResult Detailes(int id)
        {
            course obj = (from s in myDB.courses
                          where s.courseId == id
                        select s).FirstOrDefault();

            return View("Detailes", obj);
        }

        //public ActionResult updateCourse(int id)
        // {
        //    course obj = (from course in myDB.courses
        //     where course.courseId == id
        //   select course).FirstOrDefault();
        //   return View(obj);
        // }


        //public ActionResult updateCourse(course updatedCourse)
        //{
        //    var obj = (from course in myDB.courses
        //               where course.courseId == updatedCourse.courseId
        //               select course).FirstOrDefault();

        //    if (obj != null)
        //    {
        //        obj.courseName = updatedCourse.courseName;
        //        obj.isAvailable = updatedCourse.isAvailable;
        //        myDB.SaveChanges();
        //    }

        //    return RedirectToAction("getCourses");
        //}

     
    }
}
