using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ICTGWS.ViewModels
{
    public class SubjectRepo : RepositoryBase
    {

        // Get ALL subjects
        public IEnumerable<SubjectsGet> GetSubjects()
        {
            var subjects = ds.Subjects.OrderBy(s => s.Name);
            // Map to DTO objects
            return Mapper.Map<IEnumerable<SubjectsGet>>(subjects);
        }

        //Get all subjects for list
        public IEnumerable<SubjectsForList> GetSubjectsForList()
        {
            var subjects = from s in ds.Subjects
                           orderby s.Name
                           select new SubjectsForList() { SubjectId=s.SubjectId, Code=s.Code, Name=s.Name, OutlineUrl=s.OutlineUrl  };
            return subjects;
        }

        // Get all subjects that match a lookup critereon (by name and by code)
        public IEnumerable<SubjectsGet> GetSubjectsBySearch(string searchText)
        {
            var subjects = ds.Subjects.Where
                (p => p.Code.ToLower().Contains(searchText.Trim().ToLower())
                    | p.Name.ToLower().Contains(searchText.Trim().ToLower()));
            return Mapper.Map<IEnumerable<SubjectsGet>>(subjects);
        }

        // Get specific subject
        public SubjectsGet GetSubjectById(int id)
        {
            var subject= ds.Subjects.Find(id);
            // Map to DTO object
            return (subject == null) ? null : Mapper.Map<SubjectsGet>(subject);
        }


        // Get specific subject, along with its related program(s)
        public SubjectGetWithPrograms GetSubjectAndProgramsById(int id)
        {
            var subject = ds.Subjects.Include("Programs")
                .FirstOrDefault(i => i.SubjectId == id);
            // Map to DTO object; include related collection(s)
            return (subject == null) ? null : Mapper.Map<SubjectGetWithPrograms>(subject);
        }

        // Update specific subject
        public SubjectUpdate UpdateSubject(SubjectUpdate updatedSubject)
        {
            var s = ds.Subjects.Find(updatedSubject.SubjectId);

            if (s == null)
            {
                return null;
            }
            else
            {
                // For the object fetched from the data store,
                // set its values to those provided
                // (the method ignores missing properties, and navigation properties)
                ds.Entry(s).CurrentValues.SetValues(updatedSubject);
                ds.SaveChanges();
                return updatedSubject;
            }
        }

        // Add new subject
        public SubjectAdd AddSubject(SubjectAdd subject)
        {
            // Map from DTO object to domain (POCO) object
            var s = ds.Subjects.Add(Mapper.Map<ICTGWS.Models.Subject>(subject));
            ds.SaveChanges();
            // Map to DTO object
            return Mapper.Map<SubjectAdd>(s);
        }

        //Delete a subject
        public SubjectDelete DeleteSubject(int id)
        {
            var subject = ds.Subjects.Find(id);

            if (subject == null)
            {
                return null;
            }
            else
            {
                ds.Subjects.Remove(subject);
                ds.SaveChanges();
                return Mapper.Map<SubjectDelete>(subject);
            }
        }
    }
}