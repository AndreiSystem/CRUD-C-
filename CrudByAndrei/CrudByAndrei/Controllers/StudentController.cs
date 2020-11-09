using CrudByAndrei.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CrudByAndrei.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            MongoHelper.ConnectToMongoService();
            MongoHelper.student_collection =
                MongoHelper.database.GetCollection<Student>("students");

            var filter = Builders<Student>.Filter.Ne("_id","");
            var result = Models.MongoHelper.student_collection.Find(filter).ToList();

            return View(result);
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            MongoHelper.ConnectToMongoService();
            MongoHelper.student_collection =
                MongoHelper.database.GetCollection<Student>("students");
            
            var filter = Builders<Student>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = MongoHelper.student_collection.Find(filter).FirstOrDefault();

            return View(result);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();    
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                MongoHelper.ConnectToMongoService();
                MongoHelper.student_collection =
                    MongoHelper.database.GetCollection<Student>("students");

                MongoHelper.student_collection.InsertOneAsync(new Student
                {
                    firstName = collection["firstName"],
                    lastName = collection["lastName"],
                    emailAddress = collection["emailAddress"]
                }); 



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static Random random = new Random();
        private object GenerateRandomId(int number)
        {
            string strarray = "abascdasdf123423fasdfdasfc";
            return new string(Enumerable.Repeat(strarray, number).Select(d => d[random.Next(d.Length)]).ToArray());
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            MongoHelper.ConnectToMongoService();
            MongoHelper.student_collection =
                MongoHelper.database.GetCollection<Student>("students");

            var filter = Builders<Student>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = MongoHelper.student_collection.Find(filter).FirstOrDefault();

            return View(result);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                MongoHelper.ConnectToMongoService();
                MongoHelper.student_collection =
                    MongoHelper.database.GetCollection<Student>("students");

                var filter = Builders<Student>.Filter.Eq("_id", ObjectId.Parse(id));

                var update = Builders<Student>.Update
                    .Set("firstName", collection["firstName"])
                    .Set("lastName", collection["lastName"])
                    .Set("emailAddress", collection["emailAddress"]);

                var result = MongoHelper.student_collection.UpdateOneAsync(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
