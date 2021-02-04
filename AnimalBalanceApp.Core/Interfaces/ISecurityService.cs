using AnimalBalanceApp.Core.Entities;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
        Task<bool> RegisterUser(Security security);
    }
}
