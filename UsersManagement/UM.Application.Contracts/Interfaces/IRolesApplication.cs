using _01_Framework.Application;
using UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace UM.Application.Contracts.Interfaces
{
    public interface IRolesApplication
    {
        OperationResult Create(RolesViewModel command);
        OperationResult Edit(RolesViewModel command);
        OperationResult Remove(long id);
        List<RolesViewModel> Search(RolesViewModel searchmodel = null);
        RolesViewModel GetDetails(long id);
    }
}
