using _01_Framework.Domain;
using _01_Framework.Infrastructure;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.Models;
using System.Collections.Generic;

namespace PW.Domain.IRepository
{
    public interface IMessageRepository : IRepository<long, Message>
    {
        public MessageViewModel GetDetails(long Id);
        List<MessageViewModel> Search(MessageViewModel command = null);
    }
}
