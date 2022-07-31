using _01_Framework.Infrastructure.EFCore;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace PW.Infrastructure.EFCore.Repository
{
    public class CourseRepository : BaseRepository<long, Course>, ICourseRepository
    {
        private readonly EMContext _emcontext;

        public CourseRepository(EMContext emcontext) : base(emcontext)
        {
            _emcontext = emcontext;
        }

        public List<CourseViewModel> Search(CourseViewModel command = null)
        {
            var Query = _emcontext.Courses.Where(x => x.Status == true).Select(listitem => new CourseViewModel
            {
                Id = listitem.Id,
                Title = listitem.Title,
                Description = listitem.Description,
                ShowInWebSite = listitem.ShowInWebSite
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Description))
                    Query = Query.Where(x => x.Description.Contains(command.Description) || x.Title.Contains(command.Title));
                if (command.Id > 0)
                    Query = Query.Where(x => x.Id == command.Id);
                if (command.ShowInWebSite == false)
                    Query = Query.Where(x => x.ShowInWebSite == false || x.ShowInWebSite == true);
            }
            else
                Query = Query.Where(x => x.ShowInWebSite == true);
            return Query.OrderBy(x => x.Id).ToList();
        }
        public CourseViewModel GetDetails(long Id)
        {
            return _emcontext.Courses.Where(x => x.Status == true).Select(listitem => new CourseViewModel
            {
                Id = listitem.Id,
                Title = listitem.Title,
                Description = listitem.Description,
                ShowInWebSite = listitem.ShowInWebSite

            }).FirstOrDefault(x => x.Id == Id);
        }
    }
}
