using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ICTGWS.ViewModels
{
    public class SemesterRepo: RepositoryBase
    {
        // Get ALL semesters
        public IEnumerable<SemestersGet> GetSemesters()
        {
            var semesters = ds.Semesters.OrderBy(e => e.SemesterName);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<SemestersGet>>(semesters);
        }


        //Get all semesters for list
        public IEnumerable<SemestersForList> GetSemestersForList()
        {
            var semesters = from e in ds.Semesters
                           orderby e.SemesterName
                           select new SemestersForList() { SemesterName=e.SemesterName };
            return semesters;
        }

        // Get specific semester, along with courses
        public SemesterWithCourses GetSemesterAndCoursesById(int id)
        {
            var semester = ds.Semesters.Include("Courses")
                .FirstOrDefault(i => i.SemesterId == id);
            // Map to DTO object; include related collection(s)
            return (semester == null) ? null : Mapper.Map<SemesterWithCourses>(semester);
        }

        // Get all semesters that match a lookup critereon
        public IEnumerable<SemestersGet> GetSemestersByName(string searchText)
        {
            var semester = ds.Semesters.Where
                (e => e.SemesterName.ToLower().Contains(searchText.Trim().ToLower()) || e.SemesterString.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<SemestersGet>>(semester);
        }

        // Get specific semester
        public SemestersGet GetSemesterById(int id)
        {
            var semester = ds.Semesters.Find(id);
            // Map to DTO object
            return (semester == null) ? null : Mapper.Map<SemestersGet>(semester);
        }

        // Update specific semester
        public SemesterUpdate UpdateSemester(SemesterUpdate updatedSemester)
        {
            var e = ds.Semesters.Find(updatedSemester.SemesterId);

            if (e == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(e).CurrentValues.SetValues(updatedSemester);
                ds.SaveChanges();
                return updatedSemester;
            }
        }

        // Add new semester
        public SemesterAdd AddSemester(SemesterAdd semester)
        {
            // Map from DTO object to domain (POCO) object
            var e = ds.Semesters.Add(Mapper.Map<ICTGWS.Models.Semester>(semester));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<SemesterAdd>(e);
        }

        //Delete an semester
        public SemesterDelete Deletesemester(int id)
        {
            var semester = ds.Semesters.Find(id);

            if (semester == null)
            {
                return null;
            }
            else
            {
                ds.Semesters.Remove(semester);
                ds.SaveChanges();
                return Mapper.Map<SemesterDelete>(semester);
            }
        }
    }
    }
