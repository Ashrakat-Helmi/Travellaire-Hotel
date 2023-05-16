using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public double totalPrice { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public string cvv { get; set; }
        public string nameOnCard { get; set; }
        public string cardNumber { get; set; }
        public DateTime exp_date { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        public int roomId { get; set; }
        [ForeignKey("roomId")]  
        public Room room { get; set; }
    }
}
