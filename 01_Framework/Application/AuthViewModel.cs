using System.Collections.Generic;

namespace _01_Framework.Application
{
    public class AuthViewModel
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        //public List<URolesPermissionsViewModel> RolesList { get; set; }
        //public List<URolesPermissionsViewModel> PermissionsList { get; set; }
        public List<long> RolesList { get; set; }


        public AuthViewModel()
        {

        }

        public AuthViewModel(long iD, string username, string fullname, List<long> rolesList)
        {
            ID = iD;
            Username = username;
            Fullname = fullname;
            RolesList = rolesList;
        }
    }
}