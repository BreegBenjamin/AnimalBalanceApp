using AnimalBalanceApp.Core.Enumerations;

namespace AnimalBalanceApp.Core.Entities
{
    public class Security : BaseEntity
    {
        public string SecurityUser { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public RoleType UserRol { get; set; }
    }
}
