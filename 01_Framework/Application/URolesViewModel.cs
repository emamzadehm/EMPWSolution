using System.Collections.Generic;

namespace _01_Framework.Application
{
    public class URolesPermissionsViewModel
    {
        //public long ID { get; set; }
        public long UserID { get; set; }
        public List<long> RoleList { get; set; }
        public List<long> PermissionList { get; set; }
    }
}