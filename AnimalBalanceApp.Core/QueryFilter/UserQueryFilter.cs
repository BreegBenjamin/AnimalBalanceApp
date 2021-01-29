using System;

namespace AnimalBalanceApp.Core.QueryFilter
{
    public class UserQueryFilter : SocialQueryFilter
    {
        public bool GetIsActive { get; set; }
        public bool GetNotActive { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
