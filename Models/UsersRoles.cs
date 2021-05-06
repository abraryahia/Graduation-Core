using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class UsersRoles
    {
        public UsersRoles()
        {
            UsersDetails = new HashSet<UsersDetails>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public string QueryAllowed { get; set; }
        public string InsertAllowed { get; set; }
        public string UpdateAllowed { get; set; }
        public string DeleteAllowed { get; set; }

        public virtual ICollection<UsersDetails> UsersDetails { get; set; }
    }
}
