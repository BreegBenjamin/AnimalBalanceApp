using AnimalBalanceApp.Core.Entities;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IAuthorizeService
    {
        Task<string> AuthenticateUser(UserLogin login);
        Task<bool> CreateUser(Security security);
    }
}