using PW.ApplicationContracts.ViewModels;
using PW.ApplicationContracts.Interfaces;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;
using _01_Framework.Application;
using PW.Domain;

namespace PW.Application
{
    public class MessageApplication : IMessageApplication
    {
        private readonly IMessageRepository _irepository;
        private readonly IUnitOfWorkPW _IUnitOfWork;
        private readonly IEmailSender _IEmailSender;

        public MessageApplication(IMessageRepository irepository, IUnitOfWorkPW iUnitOfWork, IEmailSender iEmailSender)
        {
            _irepository = irepository;
            _IUnitOfWork = iUnitOfWork;
            _IEmailSender = iEmailSender;
        }

        public OperationResult Create(MessageViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new Message(command.Name, command.Email, command.Title, command.Description);
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

        public MessageViewModel GetDetails(long id)
        {
            return _irepository.GetDetails(id);
        }

        public List<MessageViewModel> Search(MessageViewModel searchmodel = null)
        {
            return _irepository.Search(searchmodel);
        }

        public OperationResult SendToEmail(MessageViewModel command)
        {
            _IUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            _IEmailSender.SendEmail(selecteditem.Title, selecteditem.Description, selecteditem.Email);
            selecteditem.Emailed();
            _IUnitOfWork.CommitTran();
            return operationresult.Successful();
        }
    }
}
