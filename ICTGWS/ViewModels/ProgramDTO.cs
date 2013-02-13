using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.ViewModels
{
    // GET Programs with subjects
    public class ProgramGetWithSubjects
    {
        public int ProgramId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Credential { get; set; }
        public int Semesters { get; set; }

        public ICollection<SubjectsGet> Subjects { get; set; }
       
    }


    //Get programs with students
    public class ProgramGetWithStudents
    {
        public int ProgramId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Credential { get; set; }
        public int Semesters { get; set; }

     public ICollection<StudentsGet> Students { get; set; }
    }

    //Get programs with subjects and students
    public class ProgramGetWithCollections
    {
        public int ProgramId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Credential { get; set; }
        public int Semesters { get; set; }

        public ICollection<StudentsGet> Students { get; set; }
        public ICollection<SubjectsGet> Subjects { get; set; }
    }

    //Get Programs
    public class ProgramsGet
    {
        public int ProgramId { get; set; }
        public bool IsCurrent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Credential { get; set; }
        public int Semesters { get; set; }
    }

    // GET Program for user interface list control
    public class ProgramsForList
    {
        public int ProgramId { get; set; }
        public bool IsCurrent { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public int Semesters { get; set; }

    }
        // POST
    public class ProgramAdd
    {
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
    }

        // PUT
        public class ProgramUpdate
        {
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
        }

        // DELETE
        public class ProgramDelete
        {
            public int ProgramId { get; set; }
            public bool IsCurrent { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Credential { get; set; }
            public int Semesters { get; set; }
        }

    }
