using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalBalanceApp.Core.Entitis
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string CommentDescription { get; set; }
        public DateTime PostDate { get; set; }
        public int CommentState { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
