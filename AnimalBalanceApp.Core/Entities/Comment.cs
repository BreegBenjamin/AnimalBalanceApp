using System;

namespace AnimalBalanceApp.Core.Entities
{
    public partial class Comment : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string CommentDescription { get; set; }
        public DateTime PostDate { get; set; }
        public int CommentState { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
