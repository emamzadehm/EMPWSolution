using _01_Framework.Domain;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.Models;
using System.Collections.Generic;

namespace PW.Domain.IRepository
{
    public interface IProfessorRepository : IRepository<long, Professor>
    {
        public ProfessorViewModel GetDetails(long Id);
        List<ProfessorViewModel> Search(ProfessorViewModel command = null);
    }
}
