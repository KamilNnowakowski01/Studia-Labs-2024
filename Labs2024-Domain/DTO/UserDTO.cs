﻿using Labs2024_Domain.Models;

namespace Labs2024_Domain.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
