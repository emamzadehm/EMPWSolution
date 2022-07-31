using _01_Framework.Application;
using UM.Application.Contracts.Interfaces;
using UM.Application.Contracts.ViewModels;
using UM.Domain;
using UM.Domain.UsersAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UM.Application
{
    public class RolesApplication : IRolesApplication
    {
        private readonly IUnitOfWorkUM _iunitofwork;
        private readonly IRolesRepository _irolesrepository;

        public RolesApplication(IUnitOfWorkUM iunitofwork, IRolesRepository irolesrepository)
        {
            _iunitofwork = iunitofwork;
            _irolesrepository = irolesrepository;
        }

        public OperationResult Create(RolesViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();

            var NewItem = new Role(command.RoleName, command.Description);
            _irolesrepository.Create(NewItem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(RolesViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irolesrepository.GetBy(command.ID);


            SelectedItem.Edit(command.RoleName, command.Description);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public RolesViewModel GetDetails(long id)
        {
            return _irolesrepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irolesrepository.GetBy(id);
            SelectedItem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<RolesViewModel> Search(RolesViewModel searchmodel = null)
        {
            return _irolesrepository.Search(searchmodel);
        }
    }
}
