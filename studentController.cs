using MVC9909.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC9909.Controllers
{
    public class studentController : Controller
    {
        ABCDBContext myDB = new ABCDBContext();

       
        public ActionResult getStudent()
        {
            List<student> studentList = new List<student>();
            studentList = (from student in myDB.students select student).ToList();
            return View(studentList);
        }


        //هذه الميثود تعرض صفحة ادخال البيانات
        [HttpGet]
        public ActionResult insertStudent()
        {
            return View();
        }


        // هذه الميثود تستخدم لارسال البيانات المدخله 
        [HttpPost]
        public ActionResult insertStudent(student student)
        {
            myDB.students.Add(student);
            myDB.SaveChanges();
            return RedirectToAction("getStudent");
        }

      
        public ActionResult deleteStudent(int id)
        {
            student obj = (from s in myDB.students
                           where s.studentId == id
                           select s).FirstOrDefault();

           
                myDB.students.Remove(obj);
                myDB.SaveChanges();
           

            return RedirectToAction("getStudent");
        }

      
        public ActionResult getDetails(int id)
        {
            student obj = (from s in myDB.students
                           where s.studentId == id
                           select s).FirstOrDefault();

            return View(obj);
        }
    }
}
