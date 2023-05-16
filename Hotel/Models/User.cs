using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class User
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
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
