using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labs2024_Domain.Models
{
    public class Car
    {
        [Key]
        public required int ID { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required int YearOfProduction { get; set; }
        public required string CarRegistration { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
