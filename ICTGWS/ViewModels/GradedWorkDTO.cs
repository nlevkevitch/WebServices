using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ICTGWS.ViewModels
{

    //GET Graded works
    public class GradedWorksGet
    {
        public int GradedWorkId { get; set; }
        public bool IsCurrent { get; set; }    
        public int CourseId { get; set; }    
        public string Titke { get; set; }    
        public DateTime DateCreated { get; set; }       
        public string Description { get; set; }      
        public DateTime DateDue { get; set; }      
        public int Duration { get; set; }     
        public string Category { get; set; }
        public string MoreInfoUrl { get; set; }    
        public double Value { get; set; }
        public DateTime DateAssigned { get; set; }
    }
    //GET Graded works for list
    public class GradedWorksForList
    {
         
        
        public string CourseCode { get; set; }
         
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
        
        public string Category { get; set; }
        public string MoreInfoUrl { get; set; }
        public double Value { get; set; }
         
    }


    //POST graded work
    public class GradedWorkAdd
    {
        public int GradedWorkId { get; set; }
        public bool IsCurrent { get; set; }

        [Required]
        public int CourseId { get; set; }

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

    //PUT graded work
    public class GradedWorkUpdate
    {
        public int GradedWorkId { get; set; }
        public bool IsCurrent { get; set; }

        [Required]
        public int CourseId { get; set; }

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

    //Delete graded work
    public class GradedWorkDelete
    {
        public int GradedWorkId { get; set; }
        public bool IsCurrent { get; set; }
        public int Course_Id { get; set; }
        public string Titke { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
        public int Duration { get; set; }
        public string Category { get; set; }
        public string MoreInfoUrl { get; set; }
        public double Value { get; set; }
        public DateTime DateAssigned { get; set; }
    }
}