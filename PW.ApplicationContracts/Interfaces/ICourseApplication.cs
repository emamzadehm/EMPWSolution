using _01_Framework.Application;
using PW.ApplicationContracts.ViewModels;
using System.Collections.Generic;

namespace PW.ApplicationContracts.Interfaces
{
    public interface ICourseApplication
    {
        OperationResult Create(CourseViewModel command);
        OperationResult Edit(CourseViewModel command);
        OperationResult Remove(long id);
        CourseViewModel GetDetails(long id);
        List<CourseViewModel> Search(CourseViewModel command=null);

    }
}
