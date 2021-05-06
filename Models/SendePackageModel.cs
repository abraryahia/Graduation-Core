using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation_Core.Models
{
    public class SendePackageModel
    {

    }
    public class PackagViewModel
    {
        public long ID { get; set; }
        public int Wight { get; set; }
        public string Fargial { get; set; }
        public int Price { get; set; }
        public string Describtion { get; set; }
        public string Early { get; set; }
        [Required(ErrorMessage = "this is requierd")]
        public Nullable<System.DateTime> Date { get; set; }
        public string S_SSN { get; set; }
        public string R_SSN { get; set; }
        public string Status { get; set; }
    }
    public class SenderViewModel
    {
        public long ID { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "enter Valid name")]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter the sender mobile")]
        [MaxLength(11, ErrorMessage = "the lenght must be 11 digit")]
        [MinLength(11, ErrorMessage = "the lenght must be 11 digit")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "please enter the valid   email")]
        [DataType(DataType.EmailAddress)] 
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string AddressDetails { get; set; }
        [Required(ErrorMessage = "please enter the  ssn correctly")]
        [MaxLength(14, ErrorMessage = "the lenght must be 14 digit")]
        [MinLength(14, ErrorMessage = "the lenght must be 14 digit")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "please enter the sender City")]
        public int C_ID { get; set; }
        [Required(ErrorMessage = "please enter the sender Location")]
        
        public int LocationID { get; set; }
        public virtual ICollection<ReceiverInfo> Receivers { get; set; }
        //Phone Number Regex
    }
    public class ReciverViewModel : SenderViewModel
    {

    }
}