using System.ComponentModel.DataAnnotations.Schema;

namespace ZipZop.Modals
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int VehicleId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Pending"; // Confirmed, Cancelled, etc.

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle? Vehicle { get; set; }
    }
}
