using CrudByAndrei.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudByAndrei.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Models.Student> students = new List<Models.Student>();

            Student student = new Student();

            student.firstName = "Student 1";
            student.lastName = "Student Lastname 1";
            student.emailAddress = "Student Emailaddress 1";

            students.Add(student);

            Student student2 = new Student();

            student2.firstName = "Student 1";
            student2.lastName = "Student Lastname 1";
            student2.emailAddress = "Student Emailaddress 1";

            students.Add(student2);

            Student student3 = new Student();

            student3.firstName = "Student 1";
            student3.lastName = "Student Lastname 1";
            student3.emailAddress = "Student Emailaddress 1";

            students.Add(student3);

            MongoHelper.ConnectToMongoService();
            MongoHelper.student_collection =
                MongoHelper.database.GetCollection<Student>("students");


            MongoHelper.student_collection.InsertManyAsync(students);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}