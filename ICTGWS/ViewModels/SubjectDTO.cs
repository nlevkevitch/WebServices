using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.ViewModels
{

    // GET all subjects
    public class SubjectsGet
    {
        public int SubjectId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OutlineUrl { get; set; }

        
    }
    // GET all subjects with collection
    public class SubjectGetWithCollection
    {
        public int SubjectId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OutlineUrl { get; set; }

        public ICollection<ProgramsGet> Programs { get; set; }
        public ICollection<CoursesGet> Courses { get; set; }
        
    }

    // GET all subjects with programs
    public class SubjectGetWithPrograms
    {
        public int SubjectId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OutlineUrl { get; set; }

        public ICollection<ProgramsGet> Programs { get; set; }
        
    }

    // GET all subjects with courses
    public class SubjectGetWithCourses
    {
        public int SubjectId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OutlineUrl { get; set; }

        public ICollection<CoursesGet> Courses { get; set; }

    }

    // GET all subjects for list
    public class SubjectsForList
    {
       public int SubjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OutlineUrl { get; set; }
    }

    
    // POST
    public class SubjectAdd
    {
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
    }
    // PUT
    public class SubjectUpdate
    {
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
    }

    // DELETE
    public class SubjectDelete
    {
        public int SubjectId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OutlineUrl { get; set; }
    }
}
