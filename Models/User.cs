﻿namespace Lab2_TuThiHongDiep_CSE422.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
