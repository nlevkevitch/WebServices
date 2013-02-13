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
    public class ProgramsController : ApiController
    {
        // Declare and initialize the repository
        private ProgramRepo r = new ProgramRepo();


        // GET api/programs
        public IEnumerable<ProgramsGet> GetProg()
        {
            return r.GetPrograms();
        }

        // GET api/programs?list
        public IEnumerable<ProgramsForList> GetProgForList(string list)
        {
            return r.GetProgramsForList();
        }

        // GET api/programs?search=foo
        public IEnumerable<ProgramsGet> GetProgBySearch(string search)
        {
            return r.GetProgramsBySearch(search);
        }
        // GET api/programs/5?full
        public HttpResponseMessage GetProgWithSub(int id, string full)
        {
            ProgramGetWithSubjects s = r.GetProgramAndSubjectsById(id);
            return (s == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<ProgramGetWithSubjects>(HttpStatusCode.OK, s);
        }

        // GET api/programs/5
        public HttpResponseMessage GetProgById(int id)
        {
            ProgramsGet c = r.GetProgramById(id);
            return (c == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<ProgramsGet>(HttpStatusCode.OK, c);
        }

        //POST api/programs

         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostProg(ProgramAdd program)
        {
            if (ModelState.IsValid)
            {
                // Add the new item
                var c = r.AddProgram(program);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, program);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = program.ProgramId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        
        // PUT api/programs/5
         [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutProg(int id, ProgramUpdate program)
        {
            if (ModelState.IsValid && id == program.ProgramId)
            {
                // Attempt to update the item
                var updatedProgram = r.UpdateProgram(program);
                return (updatedProgram == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse(HttpStatusCode.OK, updatedProgram);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/programs/5
         [Authorize(Roles = "Administrator")]
        public HttpResponseMessage DeleteProg(int id)
        {
            // Attempt to delete the item
            var program = r.DeleteProgram(id);

            return (program == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse(HttpStatusCode.OK, program);
        }
    }
}
