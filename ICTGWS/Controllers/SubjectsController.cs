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
    public class SubjectsController : ApiController
    {
        // Declare and initialize the repository
        private SubjectRepo r = new SubjectRepo();


        // GET api/subjects
        public IEnumerable<SubjectsGet> GetSub()
        {
            return r.GetSubjects();
        }

        // GET api/subjects?list
        public IEnumerable<SubjectsForList> GetSubForList(string list)
        {
            return r.GetSubjectsForList();
        }

        // GET api/subjects?search=foo
        public IEnumerable<SubjectsGet> GetSubBySearch(string search)
        {
            return r.GetSubjectsBySearch(search);
        }
        // GET api/subjects/5?full
        public HttpResponseMessage GetSubWithProg(int id, string full)
        {
            SubjectGetWithPrograms s = r.GetSubjectAndProgramsById(id);
            return (s == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<SubjectGetWithPrograms>(HttpStatusCode.OK, s);
        }

        // GET api/subjects/5
        public HttpResponseMessage GetSubById(int id)
        {
            SubjectsGet c = r.GetSubjectById(id);
            return (c == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<SubjectsGet>(HttpStatusCode.OK, c);
        }

        // POST api/subjects
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostSub(SubjectAdd subject)
        {
            if (ModelState.IsValid)
            {
                // Add the new item
                var c = r.AddSubject(subject);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, subject);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = subject.SubjectId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/subjects/5
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutSub(int id, SubjectUpdate subject)
        {
            if (ModelState.IsValid && id == subject.SubjectId)
            {
                // Attempt to update the item
                var updatedSubject = r.UpdateSubject(subject);
                return (updatedSubject == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse(HttpStatusCode.OK, updatedSubject);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/subjects/5
         [Authorize(Roles = "Administrator")]
        public HttpResponseMessage DeleteSub(int id)
        {
            // Attempt to delete the item
            var subject = r.DeleteSubject(id);

            return (subject == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse(HttpStatusCode.OK, subject);
        }
    }
}
