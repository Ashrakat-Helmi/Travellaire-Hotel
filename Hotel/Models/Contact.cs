using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
            [ForeignKey("userId")]
            public RegisterModel? registerModel { get; set; }
    }
}
