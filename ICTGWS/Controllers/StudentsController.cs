using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ICTGWS.ViewModels;
using ICTGWS.Models;

namespace ICTGWS.Controllers
{
    public class StudentsController : ApiController
    {
        // Declare and initialize the repository
        private StudentRepo r = new StudentRepo();

        // GET api/students
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<StudentsGet> GetStudents()
        {
            return r.GetStudents();
        }

        // GET api/students?list
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<StudentsForList> GetStudentsForList(string list)
        {
            return r.GetStudentsForList();
        }

        // GET api/students?search=foo
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<StudentsGet> GetStudentBySearch(string search)
        {
            return r.GetStudentsByName(search);
        }

        // GET api/students/5
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public HttpResponseMessage GetStudentById(int id)
        {
            StudentsGet c = r.GetStudentById(id);
            return (c == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<StudentsGet>(HttpStatusCode.OK, c);
        }

        // POST api/students
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostStusent(StudentAdd student)
        {
            if (ModelState.IsValid)
            {
                // Add the new item
                var c = r.AddStudent(student);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.StId}));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        // PUT api/students/5
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutStudent(int id, StudentUpdate student)
        {
            if (ModelState.IsValid && id == student.StId)
            {
                // Attempt to update the item
                var updatedstudent = r.UpdateStudent(student);
                return (updatedstudent == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse(HttpStatusCode.OK, updatedstudent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/students/5
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            // Attempt to delete the item
            var student = r.DeleteStudent(id);

            return (student == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse(HttpStatusCode.OK, student);
        }

    }
}
