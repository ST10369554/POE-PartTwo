﻿namespace POE_Part2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Lecturer, Coordinator, Manager
    }
}
