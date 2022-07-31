using _01_Framework.Domain;
using System.Collections.Generic;

namespace UM.Domain.UsersAgg
{
    public class Role : DomainBase
    {
        public string RoleName { get; private set; }
        public string Description { get; private set; }
        public List<UserRole> UserRoles { get; private set; }

        protected Role()
        {

        }
        public Role(string rolename, string description)
        {
            RoleName = rolename;
            Description = description;
        }
        public void Edit(string rolename, string description)
        {
            RoleName = rolename;
            Description = description;
        }
    }
}
