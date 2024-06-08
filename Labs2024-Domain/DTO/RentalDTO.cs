using Labs2024_Domain.Models;

namespace Labs2024_Domain.DTO
{
    public class RentalDTO
    {
        public int ID { get; set; }
        public int IDCar { get; set; }
        public int IDUser { get; set; }
        public RentalState State { get; set; }
        public DateTime DateStartRental { get; set; }
        public DateTime? DateCloseRental { get; set; }
    }
}
