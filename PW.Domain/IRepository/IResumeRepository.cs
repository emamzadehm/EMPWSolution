using _01_Framework.Domain;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.Models;
using System.Collections.Generic;

namespace PW.Domain.IRepository
{
    public interface IResumeRepository : IRepository<long, Resume>
    {
        public ResumeViewModel GetDetails(long Id);
        List<ResumeViewModel> Search(ResumeViewModel command = null);
    }
}
