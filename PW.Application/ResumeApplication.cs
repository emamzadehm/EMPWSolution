using _01_Framework.Application;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;
using PW.Domain;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;

namespace PW.Application
{
    public class ResumeApplication : IResumeApplication
    {
        private readonly IResumeRepository _irepository;
        private readonly IUnitOfWorkPW _IUnitOfWork;
        private readonly IFileUploader _IFileuploader;

        public ResumeApplication(IResumeRepository irepository, IUnitOfWorkPW iUnitOfWork, IFileUploader iFileuploader)
        {
            _irepository = irepository;
            _IUnitOfWork = iUnitOfWork;
            _IFileuploader = iFileuploader;
        }

        public OperationResult Create(ResumeViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var path = $"Icons//";
            var iconPath = _IFileuploader.Upload(command.IconFile, path);
            var NewItem = new Resume(command.Priority, command.FromYear, command.ToYear, command.Title, command.Description, iconPath);
            _irepository.Create(NewItem);
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(ResumeViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irepository.GetBy(command.Id);
            var path = $"Icons//";
            var iconPath = _IFileuploader.Upload(command.IconFile, path);
            SelectedItem.Edit(command.Priority, command.FromYear, command.ToYear, command.Title, command.Description, iconPath);
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Remove(long id)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irepository.GetBy(id);
            SelectedItem.Remove();
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public List<ResumeViewModel> Search(ResumeViewModel searchmodel = null)
        {
            return _irepository.Search(searchmodel);
        }
        public ResumeViewModel GetDetails(long id)
        {
            return _irepository.GetDetails(id);
        }

    }
}
