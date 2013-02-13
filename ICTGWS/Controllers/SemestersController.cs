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
    public class SemestersController : ApiController
    {
        // Declare and initialize the repository
        private SemesterRepo r = new SemesterRepo();


        // GET api/semesters
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<SemestersGet> GetSem()
        {
            return r.GetSemesters();
        }

        // GET api/semesters?list
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<SemestersForList> GetSemForList(string list)
        {
            return r.GetSemestersForList();
        }

        // GET api/semesters?search=foo
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<SemestersGet> GetSemBySearch(string search)
        {
            return r.GetSemestersByName(search);
        }
        // GET api/semesters/5?full
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public HttpResponseMessage GetSemWithSub(int id, string full)
        {
            SemesterWithCourses s = r.GetSemesterAndCoursesById(id);
            return (s == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<SemesterWithCourses>(HttpStatusCode.OK, s);
        }

        // GET api/semesters/5
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public HttpResponseMessage GetSemById(int id)
        {
            SemestersGet c = r.GetSemesterById(id);
            return (c == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<SemestersGet>(HttpStatusCode.OK, c);
        }

        //POST api/semesters
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostSem(SemesterAdd semester)
        {
            if (ModelState.IsValid)
            {
                // Add the new item
                var c = r.AddSemester(semester);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, semester);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = semester.SemesterId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/semesters/5
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutSem(int id, SemesterUpdate semester)
        {
            if (ModelState.IsValid && id == semester.SemesterId)
            {
                // Attempt to update the item
                var updatedsemester = r.UpdateSemester(semester);
                return (updatedsemester == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse(HttpStatusCode.OK, updatedsemester);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/semesters/5
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage DeleteSem(int id)
        {
            // Attempt to delete the item
            var semester = r.Deletesemester(id);

            return (semester == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse(HttpStatusCode.OK, semester);
        }
    }
}
