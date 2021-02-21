using System;

namespace AnimalBalanceApp.Core.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Telephone { get; set; }
        public int IsActive { get; set; }
        public int UserType { get; set; }
        public string ImageName { get; set; }
        public string UserPassword { get; set; }
    }
}
