using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class UserLogin
    {
        [DefaultValue(0)]

        public int ID { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Please Entre Valid Email")]
        [Display(Name ="Email Address")]
        public string userEmail { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Entre Valid Password")]

        public string userPassword { get; set; }
    
    }
}
