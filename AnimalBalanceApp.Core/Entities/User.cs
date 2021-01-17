using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalBalanceApp.Core.Entitis
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Telephone { get; set; }
        public int IsActive { get; set; }
        public int UserType { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
