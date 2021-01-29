using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User>  GetUsers(UserQueryFilter filters);
        Task<bool> InsertUser(User user);
        Task<User> GetUserForId(int UserId);
    }
}
