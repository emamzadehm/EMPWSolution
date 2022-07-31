using _01_Framework.Domain;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.Models;
using System.Collections.Generic;

namespace PW.Domain.IRepository
{
    public interface ICourseRepository : IRepository<long,Course>
    {
        public CourseViewModel GetDetails(long Id);
        List<CourseViewModel> Search(CourseViewModel command = null);
    }
}
