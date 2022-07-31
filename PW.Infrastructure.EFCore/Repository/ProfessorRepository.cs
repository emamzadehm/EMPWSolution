using _01_Framework.Infrastructure.EFCore;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace PW.Infrastructure.EFCore.Repository
{
    public class ProfessorRepository : BaseRepository<long, Professor>, IProfessorRepository
    {
        private readonly EMContext _emcontext;

        public ProfessorRepository(EMContext emcontext) : base(emcontext)
        {
            _emcontext = emcontext;
        }

        public List<ProfessorViewModel> Search(ProfessorViewModel command = null)
        {
            var Query = _emcontext.Professors.Select(listitem => new ProfessorViewModel
            {
                Id = listitem.Id,
                Name=listitem.Name,
                Family=listitem.Family,
                Address=listitem.Address,
                Email=listitem.Email,
                ImgAddress=listitem.ImgAddress,
                Level=listitem.Level,
                LinkedInURL=listitem.LinkedInURL,
                MapAddress=listitem.MapAddress,
                Tel=listitem.Tel
            });
            return Query.OrderBy(x => x.Id).ToList();
        }
        public ProfessorViewModel GetDetails(long Id)
        {
            return _emcontext.Professors.Select(listitem => new ProfessorViewModel
            {
                Id = listitem.Id,
                Name = listitem.Name,
                Family = listitem.Family,
                Address = listitem.Address,
                Email = listitem.Email,
                ImgAddress = listitem.ImgAddress,
                Level = listitem.Level,
                LinkedInURL = listitem.LinkedInURL,
                MapAddress = listitem.MapAddress,
                Tel = listitem.Tel
            }).FirstOrDefault(x => x.Id == Id);
        }
    }
}
