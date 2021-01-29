using System;
using System.Collections.Generic;

namespace AnimalBalanceApp.Core.Entities
{
    public partial class Post : BaseEntity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
        }

        public int UserId { get; set; }
        public string Title { get; set; }
        public string PostDescription { get; set; }
        public string Category { get; set; }
        public DateTime DatePost { get; set; }
        public string ContainerImagesName { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
