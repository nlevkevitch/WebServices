using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ICTGWS.ViewModels
{
    public class CourseRepo: RepositoryBase
    {
         // Get ALL courses
        public IEnumerable<CoursesGet> GetCourses()
        {
            var courses = ds.Courses.OrderBy(c => c.Subject.Code);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<CoursesGet>>(courses);
        }

        //Get all coursess for list
        public IEnumerable<CoursesForList> GetCoursesForList()
        {
            var courses = from c in ds.Courses
                           orderby c.Subject.Name
                           select new CoursesForList() { Course_code=c.Subject.Code, Day1=c.Day1, Day2=c.Day2, Room1=c.Room1, Room2=c.Room2, StartPeriod1=c.StartPeriod1, StartPeriod2=c.StartPeriod2, Professor=c.Employee.FullName};
            return courses;
        }

        // Get all coursess that match a lookup critereon
        public IEnumerable<CoursesGet> GetCoursesBySearch(string searchText)
        {
            var courses = ds.Courses.Where
                (c => c.Subject.Code.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<CoursesGet>>(courses);
        }

        // Get specific course
        public CoursesGet GetCourseById(int id)
        {
            var course = ds.Courses.Find(id);
            // Map to DTO object
            return (course == null) ? null : Mapper.Map<CoursesGet>(course);
        }


        // Get specific course, along with students
        public CourseGetWithStudents GetCourseAndStudentsById(int id)
        {
            var course = ds.Courses.Include("Students")
                .FirstOrDefault(i => i.CourseId == id);
            // Map to DTO object; include related collection(s)
            return (course == null) ? null : Mapper.Map<CourseGetWithStudents>(course);
        }

         

        // Get specific course, along with graded works
        public CourseGetWithGradedWorks GetCourseAndWorksById(int id)
        {
            var course = ds.Courses.Include("GradedWorks")
                .FirstOrDefault(i => i.CourseId == id);
            // Map to DTO object; include related collection(s)
            return (course == null) ? null : Mapper.Map<CourseGetWithGradedWorks>(course);
        }

        // Get specific course, along with students and graded works
        public CourseGetWithCollections GetCourseAndCollectionsById(int id)
        {
            var course = ds.Courses.Include("GradedWorks").Include("Students")
                .FirstOrDefault(i => i.CourseId == id);
            // Map to DTO object; include related collection(s)
            return (course == null) ? null : Mapper.Map<CourseGetWithCollections>(course);
        }

        // Update specific course
        public CourseUpdate UpdateCourse(CourseUpdate updatedCourse)
        {
            var p = ds.Courses.Find(updatedCourse.CourseId);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedCourse);
                ds.SaveChanges();
                return updatedCourse;
            }
        }

        // Add new course
        public CourseAdd AddCourse(CourseAdd course)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.Courses.Add(Mapper.Map<ICTGWS.Models.Course>(course));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<CourseAdd>(p);
        }

        //Delete a course
        public CourseDelete DeleteCourse(int id)
        {
            var course = ds.Courses.Find(id);

            if (course == null)
            {
                return null;
            }
            else
            {
                ds.Courses.Remove(course);
                ds.SaveChanges();
                return Mapper.Map<CourseDelete>(course);
            }
        }
    }
  }
