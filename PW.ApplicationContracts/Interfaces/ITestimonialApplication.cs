using _01_Framework.Application;
using PW.ApplicationContracts.ViewModels;
using System.Collections.Generic;

namespace PW.ApplicationContracts.Interfaces
{
    public interface ITestimonialApplication
    {
        OperationResult Create(TestimonialViewModel command);
        OperationResult Remove(long id);
        TestimonialViewModel GetDetails(long id);
        List<TestimonialViewModel> Search(TestimonialViewModel command);
        OperationResult ToVisible(long id);
        OperationResult ToInvisible(long id);

    }
}
