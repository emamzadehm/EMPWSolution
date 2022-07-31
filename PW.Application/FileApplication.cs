using PW.ApplicationContracts.ViewModels;
using PW.ApplicationContracts.Interfaces;
using PW.Domain.IRepository;
using System.Collections.Generic;
using PW.Domain.Models;
using _01_Framework.Application;
using PW.Domain;

namespace PW.Application
{
    public class FileApplication : IFileApplication
    {
        private readonly IFileRepository _irepository;
        private readonly IUnitOfWorkPW _IUnitOfWork;
        private readonly IFileUploader _iFileUploader;

        public FileApplication(IFileRepository irepository, IUnitOfWorkPW iUnitOfWork, IFileUploader iFileUploader)
        {
            _irepository = irepository;
            _IUnitOfWork = iUnitOfWork;
            _iFileUploader = iFileUploader;
        }

        public OperationResult Create(FileViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var path = $"Files//";
            var UploadedFileName = _iFileUploader.Upload(command.FileContent, path);
            var NewItem = new Files(command.Title, UploadedFileName, command.Description, command.FileTypeId, command.CourseId);
            _irepository.Create(NewItem);
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(FileViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            var path = $"Files//";
            var UploadedFileName = _iFileUploader.Upload(command.FileContent, path);
            selecteditem.Edit(command.Title, UploadedFileName, command.Description, command.FileTypeId, command.CourseId);
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


        public FileViewModel GetDetails(long id)
        {
            return _irepository.GetDetails(id);
        }

        public List<FileViewModel> Search(FileViewModel searchmodel = null)
        {
            return _irepository.Search(searchmodel);
        }

        public List<FileViewModel> GetbyType(int Id)
        {
            return _irepository.GetbyType(Id);
        }

    }
}
