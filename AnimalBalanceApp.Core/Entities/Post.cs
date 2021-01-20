using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalBalanceApp.Core.Entitis
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string PostDescription { get; set; }
        public string Category { get; set; }
        public DateTime DatePost { get; set; }
        public string ContainerImagesName { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
