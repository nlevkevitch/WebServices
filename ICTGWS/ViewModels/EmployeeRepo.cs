using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace ICTGWS.ViewModels
{
    public class EmployeeRepo: RepositoryBase
    {
        // Get ALL employees
        public IEnumerable<EmployeesGet> GetEmployees()
        {
            var employees = ds.Employees.OrderBy(e => e.FullName);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<EmployeesGet>>(employees);
        }

        //Get all employees for list
        public IEnumerable<EmployeesForList> GetEmployeesForList()
        {
            var employees = from e in ds.Employees
                           orderby e.FullName
                           select new EmployeesForList() { EmployeeId = e.EmployeeId, FullName = e.FullName, Email=e.Email, Telephone=e.Telephone };
            return employees;
        }

        // Get all employees that match a lookup critereon
        public IEnumerable<EmployeesGet> GetEmployeesByName(string searchText)
        {
            var employees = ds.Employees.Where
                (e => e.FullName.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<EmployeesGet>>(employees);
        }

        // Get specific employee
        public EmployeesGet GetEmployeeById(int id)
        {
            var employee = ds.Employees.Find(id);
            // Map to DTO object
            return (employee == null) ? null : Mapper.Map<EmployeesGet>(employee);
        }

        // Update specific employee
        public EmployeeUpdate UpdateEmployee(EmployeeUpdate updatedEmployee)
        {
            var e = ds.Employees.Find(updatedEmployee.EmployeeId);

            if (e == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(e).CurrentValues.SetValues(updatedEmployee);
                ds.SaveChanges();
                return updatedEmployee;
            }
        }

        // Add new employee
        public EmployeeAdd AddEmployee(EmployeeAdd employee)
        {
            // Map from DTO object to domain (POCO) object
            var e = ds.Employees.Add(Mapper.Map<ICTGWS.Models.Employee>(employee));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<EmployeeAdd>(e);
        }

        //Delete an employee
        public EmployeeDelete DeleteEmployee(int id)
        {
            var employee = ds.Employees.Find(id);

            if (employee == null)
            {
                return null;
            }
            else
            {
                ds.Employees.Remove(employee);
                ds.SaveChanges();
                return Mapper.Map<EmployeeDelete>(employee);
            }
        }
    }
}