﻿namespace ProjectManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public DateTime UserCreatedDate { get; set; }

        public Task Task { get; set; }
    }
}
