using _01_Framework.Application;
using PW.ApplicationContracts.ViewModels;
using System.Collections.Generic;

namespace PW.ApplicationContracts.Interfaces
{
    public interface IProfessorApplication
    {
        OperationResult Edit(ProfessorViewModel command);   
        ProfessorViewModel GetDetails(long id);
        List<ProfessorViewModel> Search(ProfessorViewModel command);

    }
}
