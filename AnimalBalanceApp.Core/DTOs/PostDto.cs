using System;

namespace AnimalBalanceApp.Core.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string PostDescription { get; set; }
        public string Category { get; set; }
    }
}
