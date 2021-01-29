using System;

namespace AnimalBalanceApp.Core.QueryFilter
{
    public class PostQueryFilter : SocialQueryFilter
    {
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}
