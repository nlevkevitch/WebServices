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
    public class CoursesController : ApiController
    {
        // Declare and initialize the repository
        private CourseRepo r = new CourseRepo();


        // GET api/courses
      
        public IEnumerable<CoursesGet> GetCourse()
        {
            return r.GetCourses();
        }

        // GET api/courses?list
        public IEnumerable<CoursesForList> GetCoursesForList(string list)
        {
            return r.GetCoursesForList();
        }

        // GET api/courses?search=foo
        public IEnumerable<CoursesGet> GetCoursesBySearch(string search)
        {
            return r.GetCoursesBySearch(search);
        }
        // GET api/courses/5?full
        public HttpResponseMessage GetCoursesWithCollections(int id, string full)
        {
            CourseGetWithCollections s = r.GetCourseAndCollectionsById(id);
            return (s == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<CourseGetWithCollections>(HttpStatusCode.OK, s);
        }
        // GET api/courses/5?students
        public HttpResponseMessage GetCoursesWithStudents(int id, string students)
        {
            CourseGetWithStudents s = r.GetCourseAndStudentsById(id);
            return (s == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<CourseGetWithStudents>(HttpStatusCode.OK, s);
        }

        // GET api/courses/5?gw
        public HttpResponseMessage GetCoursesWithGW(int id, string gw)
        {
            CourseGetWithGradedWorks s = r.GetCourseAndWorksById(id);
            return (s == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<CourseGetWithGradedWorks>(HttpStatusCode.OK, s);
        }

        // GET api/courses/5
        public HttpResponseMessage GetCourseById(int id)
        {
            CoursesGet c = r.GetCourseById(id);
            return (c == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<CoursesGet>(HttpStatusCode.OK, c);
        }

        //POST api/courses
        [Authorize(Roles="Faculty,Coordinator")]
        public HttpResponseMessage PostCourse(CourseAdd course)
        {
            if (ModelState.IsValid)
            {
                // Add the new item
                var c = r.AddCourse(course);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, course);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = course.CourseId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/courses/5
          [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage PutCourse(int id, CourseUpdate course)
        {
            if (ModelState.IsValid && id == course.CourseId)
            {
                // Attempt to update the item
                var updatedcourse = r.UpdateCourse(course);
                return (updatedcourse == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse(HttpStatusCode.OK, updatedcourse);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/courses/5
          [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage DeleteCourse(int id)
        {
            // Attempt to delete the item
            var course = r.DeleteCourse(id);

            return (course == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse(HttpStatusCode.OK, course);
        }
    }
}
