using _01_Framework.Domain;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.Models;
using System.Collections.Generic;

namespace PW.Domain.IRepository
{
    public interface ITestimonialRepository : IRepository<long, Testimonial>
    {
        public TestimonialViewModel GetDetails(long Id);
        List<TestimonialViewModel> Search(TestimonialViewModel command = null);
    }
}
