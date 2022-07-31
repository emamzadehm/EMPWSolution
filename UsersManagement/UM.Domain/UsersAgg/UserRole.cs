using _01_Framework.Domain;
using System;


namespace UM.Domain.UsersAgg
{
    public class UserRole: DomainBase
    {
        public long UserID { get; private set; }
        public User Users { get; private set; }
        public long RoleID { get; private set; }
        public Role Roles { get; private set; }

        protected UserRole()
        {

        }
        public UserRole(long userid, long roleid)
        {
            UserID = userid;
            RoleID = roleid;
        }
        public void Edit(long userid, long roleid)
        {
            UserID = userid;
            RoleID = roleid;
        }
    }
}
