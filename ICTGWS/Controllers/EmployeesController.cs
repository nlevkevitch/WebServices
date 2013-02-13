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
    public class EmployeesController : ApiController
    {
        // Declare and initialize the repository
        private EmployeeRepo r = new EmployeeRepo();

        // GET api/employees
        public IEnumerable<EmployeesGet> GetEmp()
        {
            return r.GetEmployees();
        }

        // GET api/employees?list
        public IEnumerable<EmployeesForList> GetEmpForList(string list)
        {
            return r.GetEmployeesForList();
        }

        // GET api/employees?search=foo
        public IEnumerable<EmployeesGet> GetEmpBySearch(string search)
        {
            return r.GetEmployeesByName(search);
        }

        // GET api/employees/5
        public HttpResponseMessage GetEmpById(int id)
        {
            EmployeesGet c = r.GetEmployeeById(id);
            return (c == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<EmployeesGet>(HttpStatusCode.OK, c);
        }

        // POST api/employees
          [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PostEmp(EmployeeAdd employee)
        {
            if (ModelState.IsValid)
            {
                // Add the new item
                var c = r.AddEmployee(employee);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employee.EmployeeId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        

        // PUT api/employees/5
          [Authorize(Roles = "Coordinator")]
        public HttpResponseMessage PutEmp(int id, EmployeeUpdate employee)
        {
            if (ModelState.IsValid && id == employee.EmployeeId)
            {
                // Attempt to update the item
                var updatedEmployee = r.UpdateEmployee(employee);
                return (updatedEmployee == null) ?
                    Request.CreateResponse(HttpStatusCode.BadRequest) :
                    Request.CreateResponse(HttpStatusCode.OK, updatedEmployee);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/employees/5
          [Authorize(Roles = "Administrator")]
        public HttpResponseMessage DeleteEmp(int id)
        {
            // Attempt to delete the item
            var employee = r.DeleteEmployee(id);

            return (employee == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse(HttpStatusCode.OK,employee );
        }

    }
}
