using System;
namespace Graduation_Core.Models
{
    public class UserViewModel{
        public int ID { get; set; }
        public string Name { get; set; }
        public string  Password { get; set; }
        public string FullName { get; set; }
        public int? RoleID { get; set; }
        public int OrderCount { get; set; }
        public virtual UsersRoles Role { get; set; }
    }
}