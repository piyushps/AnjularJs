using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AnjularCrud.Operation.Models;
using System.Net;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
namespace AnjularCrud.Operation.Controllers
{
    public class StudentController : ApiController
    {
        private StudentContext db = new StudentContext();

        /// <summary>
        /// Get the list of Student.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return db.Students.AsEnumerable();
        }

        /// <summary>
        /// Get the student record by student id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student Get(int id)
        {
            Student student = db.Students.Find(id);
            if(student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return student;
        }

        /// <summary>
        /// Insert new record to studnet table.
        /// </summary>
        /// <param name="student">studnet object that contain..FirstName,LastName,City</param>
        /// <returns></returns>
        public HttpResponseMessage Post(Student student)
        { 
            if(ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, student);
                message.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.Id }));
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        /// <summary>
        /// Update Student Record by studnet Id
        /// </summary>
        /// <param name="Id">Id of Student</param>
        /// <param name="student">studnet object that contain..FirstName,LastName,City</param>
        /// <returns></returns>
        public HttpResponseMessage Put(int Id,Student student)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if(Id != student.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Delete student record by Id. 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int Id)
        {
            Student student= db.Students.Find(Id);
            if(student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Students.Remove(student);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        //// GET: Student
        //public ActionResult Index()
        //{
        //    return View();
        //}

        

    }
}