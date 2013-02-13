using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.Models
{
    public class Program
    {
        public Program()
        {
            this.Subjects = new List<Subject>();
            this.Students = new List<Student>();
            // Default values
            IsCurrent = true;
        }

        public int ProgramId { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Program Code is required")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Program Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Program Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Program Credential is required")]
        public string Credential { get; set; }

        [Required(ErrorMessage = "Program Semesters value is required")]
        [Range(2, 8)]
        public int Semesters { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Student> Students { get; set; }
    }

    public class Subject
    {
        public Subject()
        {

            this.Programs = new List<Program>();
            this.Courses = new List<Course>();

            // Default values
            IsCurrent = true;
        }

        public int SubjectId { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Subject Code is required")]
        [MaxLength(6)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Subject Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Subject Description is required")]
        public string Description { get; set; }

        [MaxLength(200)] // Arbitrary limit
        [Required(ErrorMessage = "Subject Outline URL is required")]
        public string OutlineUrl { get; set; }

        public ICollection<Program> Programs { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

    public class Employee
    {
        public Employee()
        {
            this.Courses = new List<Course>();
            // Default values
            IsCurrent = true;
        }

        public int EmployeeId { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Employee FullName is required")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Employee Telephone is required")]
        [Range(33000, 33999)]
        public int Telephone { get; set; }

        [Required(ErrorMessage = "Employee Email is required")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Employee WebSite is required")]
        [MaxLength(100)]
        public string WebSite { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        public string Password { get; set; }

        [MaxLength(100)]
        public string DisplayName { get; set; }

        public ICollection<Course> Courses { get; set; }
    }

    public class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
            // Default values
            IsCurrent = true;
        }
        public int StId{get;set;}
        public bool IsCurrent { get; set; }
    

        [Required]
        public Program Pr { get; set; }

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


        public List<Course> Courses { get; set; }
    }

    public class Course
    {
        public Course()
        {
            this.Students = new List<Student>();
            this.GradedWorks = new List<GradedWork>();
            // Default values
            IsCurrent = true;
           
        }
        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }

        

        [Required(ErrorMessage = "Day one is required")]
        [MaxLength(10)]
        public string Day1 { get; set; }

        [Required(ErrorMessage = "Day two is required")]
        [MaxLength(10)]
        public string Day2 { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration1 { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration2 { get; set; }

        public string Room1 { get; set; }
        public string Room2 { get; set; }
        public string Section { get; set; }
        public int StartPeriod1 { get; set; }
        public int StartPeriod2 { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        public Subject Subject { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public List<Student> Students { get; set; }
        public List<GradedWork> GradedWorks { get; set; }
    }

    public class Semester
    {
        public Semester()
        {
            this.Courses = new List<Course>();
        }
        public int SemesterId { get; set; }

        [Required(ErrorMessage = "Stemester Name is required")]
        [MaxLength(20)]
        public string SemesterName { get; set; }

        [Required(ErrorMessage = "Stemester number is required")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "Stemester Year is required")]
        public int Year { get; set; }

        public string SemesterString { get; set; }

        public List<Course> Courses { get; set; }

    }

    public class GradedWork
    {
        public GradedWork()
        {
            IsCurrent = true;
        }


        public int GradedWorkId { get; set; }
        public bool IsCurrent { get; set; }

        [Required]
        public Course C { get; set; }

        [Required(ErrorMessage = "Tite of work is required")]
        [MaxLength(50)]
        public string Titke { get; set; }

        [Required(ErrorMessage = "Date Created is required")]
        public DateTime DateCreated { get; set; } 

        [MaxLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        public DateTime DateDue { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [MaxLength(20)]
        public string Category { get; set; }

        public string MoreInfoUrl { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Date Assigned is required")]
        public DateTime DateAssigned { get; set; }

    }
}

