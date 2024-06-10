using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs2024_Domain.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Role { get; set; }

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}

