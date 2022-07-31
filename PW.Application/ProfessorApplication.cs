using PW.ApplicationContracts.ViewModels;
using PW.ApplicationContracts.Interfaces;
using PW.Domain.IRepository;
using _01_Framework.Application;
using PW.Domain;
using System.Collections.Generic;

namespace PW.Application
{
    public class ProfessorApplication : IProfessorApplication
    {
        private readonly IProfessorRepository _irepository;
        private readonly IUnitOfWorkPW _IUnitOfWork;
        private readonly IFileUploader _IFileUploader;

        public ProfessorApplication(IProfessorRepository irepository, IUnitOfWorkPW iUnitOfWork, IFileUploader iFileUploader)
        {
            _irepository = irepository;
            _IUnitOfWork = iUnitOfWork;
            _IFileUploader = iFileUploader;
        }

        public OperationResult Edit(ProfessorViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            var path = $"Professor//";
            var UploadedFileName = _IFileUploader.Upload(command.IMGContent, path);
            selecteditem.Edit(command.Name, command.Family, command.Level, UploadedFileName , command.Tel, command.Email, command.Address, command.LinkedInURL, command.MapAddress);
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public ProfessorViewModel GetDetails(long id)
        {
            return _irepository.GetDetails(id);
        }

        public List<ProfessorViewModel> Search(ProfessorViewModel command)
        {
            return _irepository.Search(command);
        }
    }
}
