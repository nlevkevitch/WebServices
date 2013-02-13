using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace ICTGWS.ViewModels
{
    public class GradedWorkRepo: RepositoryBase
    {
        
            // Get ALL gradedworks
            public IEnumerable<GradedWorksGet> GetGradedWorks()
            {
                var gradedworks = ds.GradedWorks.OrderBy(e => e.Description);
                // Map to DTO objects
                return Mapper.Map<IEnumerable<GradedWorksGet>>(gradedworks);
            }

            //Get all gradedworks for list
            public IEnumerable<GradedWorksForList> GetGradedWorksForList()
            {
                var gradedworks = from e in ds.GradedWorks
                                orderby e.Description
                                select new GradedWorksForList() { Category=e.Category, CourseCode= e.C.Subject.Code, DateDue=e.DateDue, Description=e.Description, MoreInfoUrl=e.MoreInfoUrl, Value=e.Value};
                return gradedworks;
            }

            // Get all gradedworks that match a lookup critereon
            public IEnumerable<GradedWorksGet> GetGradedWorksByName(string searchText)
            {
                var gradedworks = ds.GradedWorks.Where
                    (e => e.Category.ToLower().Contains(searchText.Trim().ToLower()) || e.Description.ToLower().Contains(searchText.Trim().ToLower()));
                return Mapper.Map<IEnumerable<GradedWorksGet>>(gradedworks);
            }

            // Get specific gradedwork
            public GradedWorksGet GetGradedWorkById(int id)
            {
                var gradedwork = ds.GradedWorks.Find(id);
                // Map to DTO object
                return (gradedwork == null) ? null : Mapper.Map<GradedWorksGet>(gradedwork);
            }

            // Update specific gradedwork
            public GradedWorkUpdate UpdateGradedWork(GradedWorkUpdate updatedgradedwork)
            {
                var e = ds.GradedWorks.Find(updatedgradedwork.GradedWorkId);

                if (e == null)
                {
                    return null;
                }
                else
                {
                    // For the object fetched from the data store,
                    // set its values to those provided
                    // (the method ignores missing properties, and navigation properties)
                    ds.Entry(e).CurrentValues.SetValues(updatedgradedwork);
                    ds.SaveChanges();
                    return updatedgradedwork;
                }
            }

            // Add new gradedwork
            public GradedWorkAdd AddGradedWork(GradedWorkAdd gradedwork)
            {
                // Map from DTO object to domain (POCO) object
                var e = ds.GradedWorks.Add(Mapper.Map<ICTGWS.Models.GradedWork>(gradedwork));
                ds.SaveChanges();
                // Map to DTO object
                return Mapper.Map<GradedWorkAdd>(e);
            }

            //Delete an gradedwork
            public GradedWorkDelete DeleteGradedWork(int id)
            {
                var gradedwork = ds.GradedWorks.Find(id);

                if (gradedwork == null)
                {
                    return null;
                }
                else
                {
                    ds.GradedWorks.Remove(gradedwork);
                    ds.SaveChanges();
                    return Mapper.Map<GradedWorkDelete>(gradedwork);
                }
            }
        }

    }