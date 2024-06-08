using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs2024_Domain.Models
{
    public class Rental
    {
        [Key]
        public required int ID { get; set; }
        public required int IDCar { get; set; }
        public Car Car { get; set; }
        public required int IDUser { get; set; }
        public User User { get; set; }
        public required RentalState State { get; set; }
        public DateTime DateStartRental { get; set; }
        public DateTime? DateCloseRental { get; set; }
    }
}