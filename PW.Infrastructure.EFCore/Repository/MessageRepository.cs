using _01_Framework.Infrastructure.EFCore;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace PW.Infrastructure.EFCore.Repository
{
    public class MessageRepository : BaseRepository<long, Message>, IMessageRepository
    {
        private readonly EMContext _emcontext;

        public MessageRepository(EMContext emcontext) : base(emcontext)
        {
            _emcontext = emcontext;
        }

        public List<MessageViewModel> Search(MessageViewModel command = null)
        {
            var Query = _emcontext.Messages.Where(x => x.Status == true).Select(listitem => new MessageViewModel
            {
                Id = listitem.Id,
                Name=listitem.Name,
                Email=listitem.Email,
                CreatedDate=listitem.CreatedDate,
                Title = listitem.Title,
                Description = listitem.Description,
                IsEmailed=listitem.IsEmailed
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Description))
                    Query = Query.Where(x => x.Description.Contains(command.Description) || x.Title.Contains(command.Title));
                if (command.Id > 0)
                    Query = Query.Where(x => x.Id == command.Id);
            }
            return Query.OrderBy(x => x.Id).ToList();
        }
        public MessageViewModel GetDetails(long Id)
        {
            return _emcontext.Messages.Where(x => x.Status == true).Select(listitem => new MessageViewModel
            {
                Id = listitem.Id,
                Name = listitem.Name,
                Email = listitem.Email,
                CreatedDate = listitem.CreatedDate,
                Title = listitem.Title,
                Description = listitem.Description,
                IsEmailed = listitem.IsEmailed
            }).FirstOrDefault(x => x.Id == Id);
        }
    }
}
