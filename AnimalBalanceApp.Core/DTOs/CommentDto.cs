using System;

namespace AnimalBalanceApp.Core.DTOs
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string CommentDescription { get; set; }
        public DateTime PostDate { get; set; }
        public int CommentState { get; set; }
    }
}
