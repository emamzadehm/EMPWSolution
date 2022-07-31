using _01_Framework.Application;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;
using PW.Domain;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;

namespace PW.Application
{
    public class TestimonialApplication : ITestimonialApplication
    {
        private readonly ITestimonialRepository _irepository;
        private readonly IUnitOfWorkPW _IUnitOfWork;
        private readonly IFileUploader _ifileuploader;

        public TestimonialApplication(ITestimonialRepository irepository, IUnitOfWorkPW iUnitOfWork, IFileUploader ifileuploader)
        {
            _irepository = irepository;
            _IUnitOfWork = iUnitOfWork;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(TestimonialViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var path = $"TestimonialsPhoto//";
            var StudentImgFileName = _ifileuploader.Upload(command.IMG, path);
            //var StuImg=_ifileuploader.Upload(command.StudentImg,)
            var NewItem = new Testimonial(command.StudentName, StudentImgFileName, command.StudentEmail, command.CourseName, command.UniversityName, command.EduYear, command.Title, command.Description);
            _irepository.Create(NewItem);
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

        public TestimonialViewModel GetDetails(long id)
        {
            return _irepository.GetDetails(id);
        }

        public List<TestimonialViewModel> Search(TestimonialViewModel searchmodel = null)
        {
            return _irepository.Search(searchmodel);
        }

        public OperationResult ToInvisible(long id)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var selectedtestimonial = _irepository.GetBy(id);
            selectedtestimonial.ToInvisible();
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult ToVisible(long id)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var selectedtestimonial = _irepository.GetBy(id);
            selectedtestimonial.ToVisible();
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

    }
}
