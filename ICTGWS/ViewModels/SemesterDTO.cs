using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ICTGWS.ViewModels
{

    //Get semesters with courses
    public class SemesterWithCourses
    {
        public int semesterId { get; set; }

        [Required(ErrorMessage = "Stemester Name is required")]
        [MaxLength(20)]
        public string SemesterName { get; set; }

        [Required(ErrorMessage = "Stemester number is required")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "Stemester Year is required")]
        public int Year { get; set; }

        public string SemesterString { get; set; }

        public List<CoursesGet> Courses { get; set; }
    }

    //Get semesters
    public class SemestersGet
    {
        public int SemesterId { get; set; }

        [Required(ErrorMessage = "Stemester Name is required")]
        [MaxLength(20)]
        public string SemesterName { get; set; }

        [Required(ErrorMessage = "Stemester number is required")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "Stemester Year is required")]
        public int Year { get; set; }

        public string SemesterString { get; set; }
    }

    //Get semesters
    public class SemestersForList
    {
        
        [Required(ErrorMessage = "Stemester Name is required")]
        [MaxLength(20)]
        public string SemesterName { get; set; }
    }

    //POST semester
    public class SemesterAdd
    {
        public int SemesterId { get; set; }

        [Required(ErrorMessage = "Stemester Name is required")]
        [MaxLength(20)]
        public string SemesterName { get; set; }

        [Required(ErrorMessage = "Stemester number is required")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "Stemester Year is required")]
        public int Year { get; set; }

        public string SemesterString { get; set; }

    }

    //PUT semester
    public class SemesterUpdate
    {
        public int SemesterId { get; set; }

        [Required(ErrorMessage = "Stemester Name is required")]
        [MaxLength(20)]
        public string SemesterName { get; set; }

        [Required(ErrorMessage = "Stemester number is required")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "Stemester Year is required")]
        public int Year { get; set; }

        public string SemesterString { get; set; }

    }
    //Delete semester
    public class SemesterDelete
    {
        public int SemesterId { get; set; }   
        public string SemesterName { get; set; }    
        public int SemesterNumber { get; set; }
        public int Year { get; set; }
        public string SemesterString { get; set; }

    }
}