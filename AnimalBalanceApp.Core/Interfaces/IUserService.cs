using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User>  GetUsers(UserQueryFilter filters);
        Task<ApiMessages> InsertUser(User user);
        Task<User> GetUserById(int userId);
        Task<ApiMessages> DeleteUser(int userId);
        Task<ApiMessages> UpdateUser(User user);
        Task<ApiMessages> UpdatePassword(int id, string password);
    }
}
