using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Hotel.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string roomName { get; set; }
        [Required]
        public string roomType { get; set; }
        [Required]
        public double priceParNight { get; set; }
        [Required]
        public bool availiablilty { get; set; }
        public int numberOfBookingTimes { get; set; }
        [Display(Name = "Image")]
        [DefaultValue("Rectangle 1138.png")]
        public string room_Pic { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
