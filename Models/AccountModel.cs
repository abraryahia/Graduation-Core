using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Core.Models
{
    public class AccountModel
    {

    }
    public class LoginViewModel 
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public long ID { get;set;}
        public string FullName { get; set; }
}

    public class ProfileViewModel : LoginViewModel
    {
       
    }
    
    public class RegisterViewModel : SenderViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        public string FullName { get; set; }
        public int? Role { get; set; }
        
    }


}