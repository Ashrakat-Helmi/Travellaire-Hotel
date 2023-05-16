using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        [Phone]
        public string userMobile { get; set; }
        [Required]
        [EmailAddress]
        public string userEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string userPass { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Not match with password")]
        public string confirmPass { get; set; }
    }
}
