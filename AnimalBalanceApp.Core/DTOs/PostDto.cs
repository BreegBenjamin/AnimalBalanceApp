using System;

namespace AnimalBalanceApp.Core.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string PostDescription { get; set; }
        public string Category { get; set; }
        public DateTime DatePost { get; set; }
    }
}
