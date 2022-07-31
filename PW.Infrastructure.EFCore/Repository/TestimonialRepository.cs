using _01_Framework.Infrastructure.EFCore;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace PW.Infrastructure.EFCore.Repository
{
    public class TestimonialRepository : BaseRepository<long, Testimonial>, ITestimonialRepository
    {

        private readonly EMContext _emcontext;
        public TestimonialRepository(EMContext emcontext) : base(emcontext)
        {
            _emcontext = emcontext;
        }
        public List<TestimonialViewModel> Search(TestimonialViewModel command = null)
        {
            var Query = _emcontext.Testimonials.Where(x => x.Status == true).Select(listitem => new TestimonialViewModel
            {
                Id = listitem.Id,
                CourseName = listitem.CourseName,
                StudentName = listitem.StudentName,
                UniversityName = listitem.UniversityName,
                StudentImg = listitem.StudentImg,
                EduYear = listitem.EduYear,
                IsVisible = listitem.IsVisible,
                StudentEmail = listitem.StudentEmail,
                Title = listitem.Title,
                Description = listitem.Description,
                CreatedDate = listitem.CreatedDate
            });
            if(command!=null)
            {
                if (!string.IsNullOrWhiteSpace(command.Description))
                    Query = Query.Where(x => x.Description.Contains(command.Description) || x.Title.Contains(command.Title));
                if (command.Id > 0)
                    Query = Query.Where(x => x.Id == command.Id);
            }
            return Query.OrderBy(x => x.Id).ToList();
        }
        public TestimonialViewModel GetDetails(long Id)
        {
            return _emcontext.Testimonials.Where(x => x.Status == true).Select(listitem => new TestimonialViewModel
            {
                Id=listitem.Id,
                CourseName=listitem.CourseName,
                StudentName=listitem.StudentName,
                UniversityName=listitem.UniversityName,
                StudentImg=listitem.StudentImg,
                EduYear=listitem.EduYear,
                IsVisible=listitem.IsVisible,
                StudentEmail=listitem.StudentEmail,
                Title=listitem.Title,
                Description=listitem.Description,
                CreatedDate=listitem.CreatedDate
            }).FirstOrDefault(x=>x.Id==Id);
        }


    }
}
