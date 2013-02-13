using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace ICTGWS.ViewModels
{
    public class StudentRepo: RepositoryBase
    {
         
            // Get ALL students
            public IEnumerable<StudentsGet> GetStudents()
            {
                var students = ds.Students.OrderBy(e => e.LastName);
                // Map to DTO objects
                return Mapper.Map<IEnumerable<StudentsGet>>(students);
            }

            //Get all students for list
            public IEnumerable<StudentsForList> GetStudentsForList()
            {
                var students = from e in ds.Students
                                orderby e.LastName
                                select new StudentsForList() { DisplayName=e.DisplayName, ProgramCode=e.Pr.Code};
                return students;
            }

            // Get all students that match a lookup critereon
            public IEnumerable<StudentsGet> GetStudentsByName(string searchText)
            {
                var students = ds.Students.Where
                    (e => e.LastName.ToLower().Contains(searchText.Trim().ToLower()) || e.DisplayName.ToLower().Contains(searchText.Trim().ToLower()));
                return Mapper.Map<IEnumerable<StudentsGet>>(students);
            }

            // Get specific student
            public StudentsGet GetStudentById(int id)
            {
                var student = ds.Students.Find(id);
                // Map to DTO object
                return (student == null) ? null : Mapper.Map<StudentsGet>(student);
            }

            // Update specific student
            public StudentUpdate UpdateStudent(StudentUpdate updatedstudent)
            {
                var e = ds.Students.Find(updatedstudent.StudentId);

                if (e == null)
                {
                    return null;
                }
                else
                {
                    // For the object fetched from the data store,
                    // set its values to those provided
                    // (the method ignores missing properties, and navigation properties)
                    ds.Entry(e).CurrentValues.SetValues(updatedstudent);
                    ds.SaveChanges();
                    return updatedstudent;
                }
            }

            // Add new student
            public StudentAdd AddStudent(StudentAdd student)
            {
                // Map from DTO object to domain (POCO) object
                var e = ds.Students.Add(Mapper.Map<ICTGWS.Models.Student>(student));
                ds.SaveChanges();
                // Map to DTO object
                return Mapper.Map<StudentAdd>(e);
            }

            //Delete an student
            public StudentDelete DeleteStudent(int id)
            {
                var student = ds.Students.Find(id);

                if (student == null)
                {
                    return null;
                }
                else
                {
                    ds.Students.Remove(student);
                    ds.SaveChanges();
                    return Mapper.Map<StudentDelete>(student);
                }
            }
        }

    }
    

