using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ICTGWS.ViewModels
{

    //Get all students
    public class StudentsGet
    {
        public int StId { get; set; }
        public bool IsCurrent { get; set; }
        public string ProgramId { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    //Get students with all courses
    public class StudentGetWithCourses
    {
        public int StId { get; set; }
        public bool IsCurrent { get; set; }
        public string ProgramId { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<CoursesGet> Courses { get; set; }
    }

    //Get students for list
    public class StudentsForList
    {
        public string DisplayName { get; set; }
        public string ProgramCode { get; set; }
    }

    //Post new student
    public class StudentAdd
    {
        public int StId{get;set;}
        public bool IsCurrent { get; set; }

        public string ProgramId { get; set; }

        [Required(ErrorMessage = "Student Given Name is required")]
        [MaxLength(50)]
        public string GivenName { get; set; }
        
        [Required(ErrorMessage = "Student Last Name is required")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Student card number is required")]
        public int StudentId{get;set;}

         [MaxLength(100)]
        public string DisplayName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
}

    // PUT
    public class StudentUpdate
    {
        public int StId { get; set; }
        public bool IsCurrent { get; set; }

        public string ProgramId { get; set; }

        [Required(ErrorMessage = "Student Given Name is required")]
        [MaxLength(50)]
        public string GivenName { get; set; }

        [Required(ErrorMessage = "Student Last Name is required")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Student card number is required")]
        public int StudentId { get; set; }

        [MaxLength(100)]
        public string DisplayName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    // Delete
    public class StudentDelete
    {
        public int StId { get; set; }
        public bool IsCurrent { get; set; }
        public string ProgramId { get; set; }
        public string GivenName { get; set; }       
        public string LastName { get; set; }       
        public int StudentId { get; set; }       
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}