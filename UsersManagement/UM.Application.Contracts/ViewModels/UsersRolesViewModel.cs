using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UM.Application.Contracts.ViewModels
{
    public class UsersRolesViewModel
    {
        public long ID { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long UserID { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleID { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }

        public List<UsersRolesViewModel> UsersList { get; set; }
        public List<UsersRolesViewModel> RolesList { get; set; }

        //public List<int> RolesIdList { get; set; }


        public bool Status { get; set; }
        public string Fullname { get; set; }
    }
}
