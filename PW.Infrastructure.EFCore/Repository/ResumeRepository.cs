using _01_Framework.Infrastructure.EFCore;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace PW.Infrastructure.EFCore.Repository
{
    public class ResumeRepository : BaseRepository<long, Resume>, IResumeRepository
    {
        private readonly EMContext _emcontext;
        public ResumeRepository(EMContext emcontext) : base(emcontext)
        {
            _emcontext = emcontext;
        }

        public List<ResumeViewModel> Search(ResumeViewModel command = null)
        {
            var Query = _emcontext.Resumes.Where(x => x.Status == true).Select(listitem => new ResumeViewModel
            {
                Id = listitem.Id,
                Title = listitem.Title,
                FromYear=listitem.FromYear,
                Priority=listitem.Priority,
                ToYear=listitem.ToYear,
                Description = listitem.Description,
                Icon=listitem.Icon
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Description))
                    Query = Query.Where(x => x.Description.Contains(command.Description) || x.Title.Contains(command.Title));
                if (command.Id > 0)
                    Query = Query.Where(x => x.Id == command.Id);
            }
            return Query.OrderBy(x => x.Id).ToList();
        }
        public ResumeViewModel GetDetails(long Id)
        {
            return _emcontext.Resumes.Where(x => x.Status == true).Select(listitem => new ResumeViewModel
            {
                Id = listitem.Id,
                Title = listitem.Title,
                FromYear = listitem.FromYear,
                Priority = listitem.Priority,
                ToYear = listitem.ToYear,
                Description = listitem.Description,
                Icon = listitem.Icon
            }).FirstOrDefault(x => x.Id == Id);
        }
    }
}
