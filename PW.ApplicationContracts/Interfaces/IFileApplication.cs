using _01_Framework.Application;
using PW.ApplicationContracts.ViewModels;
using System.Collections.Generic;

namespace PW.ApplicationContracts.Interfaces
{
    public interface IFileApplication
    {
        OperationResult Create(FileViewModel command);
        OperationResult Edit(FileViewModel command);
        OperationResult Remove(long id);
        FileViewModel GetDetails(long id);
        List<FileViewModel> GetbyType(int Id);
        List<FileViewModel> Search(FileViewModel command);

    }
}
