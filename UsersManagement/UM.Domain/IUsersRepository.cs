using _01_Framework.Domain;
using UM.Application.Contracts.ViewModels;
using UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace UM.Domain
{
    public interface IUsersRepository : IRepository<long, User>
    {
        Dictionary<long, List<UsersViewModel>> Search(UsersViewModel command = null);
        void Save();
        UsersViewModel GetDetails(long id);
        User GetByUsername(string username);
    }
}
