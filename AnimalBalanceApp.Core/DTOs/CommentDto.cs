using System;

namespace AnimalBalanceApp.Core.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string CommentDescription { get; set; }
        public DateTime PostDate { get; set; }
        public int CommentState { get; set; }
    }
}
