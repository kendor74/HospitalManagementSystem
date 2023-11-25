﻿namespace Hospital_Managment_System.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string MaterialState { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
