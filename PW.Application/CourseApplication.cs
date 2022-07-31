using PW.ApplicationContracts.ViewModels;
using PW.ApplicationContracts.Interfaces;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;
using _01_Framework.Application;
using PW.Domain;

namespace PW.Application
{
    public class CourseApplication : ICourseApplication
    {

        private readonly ICourseRepository _irepository;
        private readonly IUnitOfWorkPW _IUnitOfWork;

        public CourseApplication(ICourseRepository irepository, IUnitOfWorkPW iUnitOfWork)
        {
            _irepository = irepository;
            _IUnitOfWork = iUnitOfWork;
        }

        public OperationResult Create(CourseViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new Course(command.Title, command.Description, command.ShowInWebSite);
            _irepository.Create(NewItem);
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CourseViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irepository.GetBy(command.Id);
            SelectedItem.Edit(command.Title, command.Description, command.ShowInWebSite);
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

        public CourseViewModel GetDetails(long id)
        {
            return _irepository.GetDetails(id);
        }

        public List<CourseViewModel> Search(CourseViewModel searchmodel = null)
        {
            return _irepository.Search(searchmodel);
        }
    }
}
