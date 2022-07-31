using _01_Framework.Application;
using PW.ApplicationContracts.ViewModels;
using System.Collections.Generic;

namespace PW.ApplicationContracts.Interfaces
{
    public interface IMessageApplication
    {
        OperationResult Create(MessageViewModel command);
        OperationResult Remove(long id);
        MessageViewModel GetDetails(long id);
        List<MessageViewModel> Search(MessageViewModel command);
        OperationResult SendToEmail(MessageViewModel command);

    }
}
