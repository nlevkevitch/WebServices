using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ICTGWS.ViewModels
{

    //Get all courses
    public class CoursesGet
    {
        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public int Duration1 { get; set; }
        public int Duration2 { get; set; }
        public string Room1 { get; set; }
        public string Room2 { get; set; }
        public string Section { get; set; }
        public int StartPeriod1 { get; set; }
        public int StartPeriod2 { get; set; }
        public int SemesterId { get; set; }
        public int SubjectId { get; set; }
        public int EmployeeId { get; set; }
    }

    //Get all courses
    public class CoursesForList
    {
         
        
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        
        public string Room1 { get; set; }
        public string Room2 { get; set; }
        
        public int StartPeriod1 { get; set; }
        public int StartPeriod2 { get; set; }
        public string Course_code { get; set; }
        public string Professor { get; set; }
    }


    //Get courses with students
    public class CourseGetWithStudents
    {
        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public int Duration1 { get; set; }
        public int Duration2 { get; set; }
        public string Room1 { get; set; }
        public string Room2 { get; set; }
        public string Section { get; set; }
        public int StartPeriod1 { get; set; }
        public int StartPeriod2 { get; set; }
        public int SemesterId { get; set; }
        public int SubjectId { get; set; }
        public int EmployeeId { get; set; }

        public List<StudentsGet> Students { get; set; }
    }

    //Get courses with graded works
    public class CourseGetWithGradedWorks
    {
        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public int Duration1 { get; set; }
        public int Duration2 { get; set; }
        public string Room1 { get; set; }
        public string Room2 { get; set; }
        public string Section { get; set; }
        public int StartPeriod1 { get; set; }
        public int StartPeriod2 { get; set; }
        public int SemesterId { get; set; }
        public int SubjectId { get; set; }
        public int EmployeeId { get; set; }

        public List<GradedWorksGet> GardedWorks { get; set; }
    }

    //Get courses with all collections
    public class CourseGetWithCollections
    {
        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public int Duration1 { get; set; }
        public int Duration2 { get; set; }
        public string Room1 { get; set; }
        public string Room2 { get; set; }
        public string Section { get; set; }
        public int StartPeriod1 { get; set; }
        public int StartPeriod2 { get; set; }
        public int Semester_Id { get; set; }
        public int Subject_Id { get; set; }
        public int Employee_Id { get; set; }

        public List<GradedWorksGet> GardedWorks { get; set; }
        public List<StudentsGet> Students { get; set; }
    }

     
   
    //POST Course
    public class CourseAdd
    {

        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Day 1 is required")]
        [MaxLength(10)]
        public string Day1 { get; set; }

        [Required(ErrorMessage = "Day 1 is required")]
        [MaxLength(10)]
        public string Day2 { get; set; }

        [Required]
        public int Duration1 { get; set; }

        [Required]
        public int Duration2 { get; set; }

        [MaxLength(10)]
        public string Room1 { get; set; }

        [MaxLength(10)]
        public string Room2 { get; set; }

        public string Section { get; set; }

        public int StartPeriod1 { get; set; }

        public int StartPeriod2 { get; set; }

        [Required]
        public int SemesterId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int EmployeeId { get; set; }


    }


    //PUT course

    public class CourseUpdate
    {

        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Day 1 is required")]
        [MaxLength(10)]
        public string Day1 { get; set; }

        [Required(ErrorMessage = "Day 1 is required")]
        [MaxLength(10)]
        public string Day2 { get; set; }

        [Required]
        public int Duration1 { get; set; }

        [Required]
        public int Duration2 { get; set; }

        [MaxLength(10)]
        public string Room1 { get; set; }

        [MaxLength(10)]
        public string Room2 { get; set; }

        public string Section { get; set; }

        public int StartPeriod1 { get; set; }

        public int StartPeriod2 { get; set; }

        [Required]
        public int Semester_Id { get; set; }

        [Required]
        public int Subject_Id { get; set; }

        [Required]
        public int Employee_Id { get; set; }


    }

    public class CourseDelete
    {

        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public int Duration1 { get; set; }
        public int Duration2 { get; set; }
        public string Room1 { get; set; }
        public string Room2 { get; set; }
        public string Section { get; set; }
        public int StartPeriod1 { get; set; }
        public int StartPeriod2 { get; set; }
        public int Semester_Id { get; set; }
        public int Subject_Id { get; set; }
        public int Employee_Id { get; set; }


    }

}