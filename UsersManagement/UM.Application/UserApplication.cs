using _01_Framework.Application;
using UM.Application.Contracts.Interfaces;
using UM.Application.Contracts.ViewModels;
using UM.Domain;
using UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace UM.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUsersRepository _iuserRepository;
        private readonly IUsersRolesRepository _iusersrolesRepository;
        private readonly IUnitOfWorkUM _iUnitOfWork;
        private readonly IFileUploader _ifileuploader;
        private readonly IPasswordHasher _ipasswordhasher;
        private readonly IAuthHelper _iauthhelper;

        public UserApplication(IUsersRepository iuserRepository, IUsersRolesRepository iusersrolesRepository,
            IUnitOfWorkUM iUnitOfWork, IFileUploader ifileuploader, IPasswordHasher ipasswordhasher,
            IAuthHelper iauthhelper)
        {
            _iuserRepository = iuserRepository;
            _iusersrolesRepository = iusersrolesRepository;
            _iUnitOfWork = iUnitOfWork;
            _ifileuploader = ifileuploader;
            _ipasswordhasher = ipasswordhasher;
            _iauthhelper = iauthhelper;
        }

        public OperationResult Create(UsersViewModel command)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var path = $"UsersManagement//";
            var foldername = command.LastName + " " + command.FirstName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            var password = _ipasswordhasher.Hash(command.Password);
            var NewItem = new User(command.FirstName, command.LastName, command.Sex, command.Email, filenameIMG, command.Tel, password);
            _iuserRepository.Create(NewItem);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }
        public OperationResult Edit(UsersViewModel command)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iuserRepository.GetBy(command.ID);
            var path = $"UsersManagement//";
            var foldername = command.LastName + " " + command.FirstName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            SelectedItem.Edit(command.FirstName, command.LastName, command.Sex, command.Tel, filenameIMG);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Remove(long id)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iuserRepository.GetBy(id);
            SelectedItem.Remove();
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public UsersViewModel GetDetails(long id)
        {
            return _iuserRepository.GetDetails(id);
        }

        public Dictionary<long, List<UsersViewModel>> Search(UsersViewModel searchmodel = null)
        {
            return _iuserRepository.Search(searchmodel);
        }

        public OperationResult ChangePassword(long uid, string password)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iuserRepository.GetBy(uid);
            var Password = _ipasswordhasher.Hash(password);
            SelectedItem.ChangePassword(Password);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult CreateRole(long roleId, long userId)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var NewUserRole = new UserRole(userId, roleId);
            _iusersrolesRepository.Create(NewUserRole);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult RemoveRole(long roleId, long userId)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iusersrolesRepository.GetByUserRole(userId, roleId);
            SelectedItem.Remove();
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Login(LoginViewModel command)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var account = _iuserRepository.GetByUsername(command.Username);
            if (account == null)
                return operationresult.Failed(ValidationMessages.InvalidUsernameOrPassword);
            (bool Verified, bool NeedsUpgrade) result = _ipasswordhasher.Check(account.Password, command.Password);
            if (result.Verified == false)
                return operationresult.Failed(ValidationMessages.InvalidUsernameOrPassword);

            var accountroles = _iusersrolesRepository.GetRolePermissionByUser(account.ID)
                .RolesList.Select(x => x.RoleID).ToList();

            var fullname = account.Sex.ToSexName() + " " + account.FirstName + " " + account.LastName;

            var authviewmodel = new AuthViewModel(account.ID, account.Email, fullname, accountroles);

            _iauthhelper.SignIn(authviewmodel);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public void Logout()
        {
            _iauthhelper.SignOut();
        }
    }
}
