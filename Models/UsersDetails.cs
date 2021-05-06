using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class UsersDetails
    {
        public long UserId { get; set; }
        public string UsrName { get; set; }
        public string UserPassword { get; set; }
        public string UserFullName { get; set; }
        public int RoleId { get; set; }
        public int Count { get; set; }

        public virtual UsersRoles Role { get; set; }
    }
}
