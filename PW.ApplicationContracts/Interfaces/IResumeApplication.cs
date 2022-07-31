using _01_Framework.Application;
using PW.ApplicationContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PW.ApplicationContracts.Interfaces
{
    public interface IResumeApplication

    {
        OperationResult Create(ResumeViewModel command);
        OperationResult Edit(ResumeViewModel command);
        OperationResult Remove(long id);
        ResumeViewModel GetDetails(long id);
        List<ResumeViewModel> Search(ResumeViewModel command);

    }
}
