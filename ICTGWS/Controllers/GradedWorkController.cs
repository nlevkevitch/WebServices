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
    public class GradedWorksController : ApiController
    {
        // Declare and initialize the repository
        private GradedWorkRepo r = new GradedWorkRepo();

        // GET api/gradedworks
          [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<GradedWorksGet> GetGW()
        {
            return r.GetGradedWorks();
        }

        // GET api/gradedworks?list
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<GradedWorksForList> GetGWForList(string list)
        {
            return r.GetGradedWorksForList();
        }

        // GET api/gradedworks?search=foo
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public IEnumerable<GradedWorksGet> GetGWBySearch(string search)
        {
            return r.GetGradedWorksByName(search);
        }

        // GET api/gradedworks/5
         [Authorize(Roles = "Faculty,Coordinator, Student, Administrator")]
        public HttpResponseMessage GetGWById(int id)
        {
            GradedWorksGet c = r.GetGradedWorkById(id);
            return (c == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<GradedWorksGet>(HttpStatusCode.OK, c);
        }

        // POST api/gradedworks
         [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage PostGW(GradedWorkAdd gradedwork)
        {
            if (ModelState.IsValid)
            {
                // Add the new item
                var c = r.AddGradedWork(gradedwork);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, gradedwork);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = gradedwork.GradedWorkId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        // PUT api/gradedworks/5
         [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage PutGW(int id, GradedWorkUpdate gradedwork)
        {
            if (ModelState.IsValid && id == gradedwork.GradedWorkId)
            {
                // Attempt to update the item
                var updatedgradedwork = r.UpdateGradedWork(gradedwork);
                return (updatedgradedwork == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse(HttpStatusCode.OK, updatedgradedwork);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/gradedworks/5
         [Authorize(Roles = "Faculty,Coordinator")]
        public HttpResponseMessage DeleteGW(int id)
        {
            // Attempt to delete the item
            var gradedwork = r.DeleteGradedWork(id);

            return (gradedwork == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse(HttpStatusCode.OK, gradedwork);
        }

    }
}
