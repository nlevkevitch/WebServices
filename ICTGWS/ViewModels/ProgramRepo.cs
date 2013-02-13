using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ICTGWS.ViewModels
{
    public class ProgramRepo: RepositoryBase
    {

         // Get ALL programs
        public IEnumerable<ProgramsGet> GetPrograms()
        {
            var programs = ds.Programs.OrderBy(p => p.Name);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<ProgramsGet>>(programs);
        }

        //Get all programs for list
        public IEnumerable<ProgramsForList> GetProgramsForList()
        {
            var programs = from p in ds.Programs
                           orderby p.Name
                           select new ProgramsForList() {Name = p.Name, IsCurrent=p.IsCurrent, Code=p.Code, Semesters=p.Semesters };
            return programs;
        }

        // Get all programs that match a lookup critereon (by name and by code)
        public IEnumerable<ProgramsGet> GetProgramsBySearch(string searchText)
        {
            var programs = ds.Programs.Where
                (p => p.Code.ToLower().Contains(searchText.Trim().ToLower() )
                    | p.Name.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<ProgramsGet>>(programs);
        }

        // Get specific program
        public ProgramsGet GetProgramById(int id)
        {
            var program = ds.Programs.Find(id);
            // Map to DTO object
            return (program == null) ? null : Mapper.Map<ProgramsGet>(program);
        }


        // Get specific program, along with its related subjects
        public ProgramGetWithSubjects GetProgramAndSubjectsById(int id)
        {
            var program = ds.Programs.Include("Subjects")
                .FirstOrDefault(i => i.ProgramId == id);
            // Map to DTO object; include related collection(s)
            return (program == null) ? null : Mapper.Map<ProgramGetWithSubjects>(program);
        }

        // Update specific program
        public ProgramUpdate UpdateProgram(ProgramUpdate updatedProgram)
        {
            var p = ds.Programs.Find(updatedProgram.ProgramId);

            if (p == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(p).CurrentValues.SetValues(updatedProgram);
                ds.SaveChanges();
                return updatedProgram;
            }
        }

        // Add new program
        public ProgramAdd AddProgram(ProgramAdd program)
        {
            // Map from DTO object to domain (POCO) object
            var p = ds.Programs.Add(Mapper.Map<ICTGWS.Models.Program>(program));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<ProgramAdd>(p);
        }

        //Delete a program
        public ProgramDelete DeleteProgram(int id)
        {
            var program = ds.Programs.Find(id);

            if (program == null)
            {
                return null;
            }
            else
            {
                ds.Programs.Remove(program);
                ds.SaveChanges();
                return Mapper.Map<ProgramDelete>(program);
            }
        }
    }
}