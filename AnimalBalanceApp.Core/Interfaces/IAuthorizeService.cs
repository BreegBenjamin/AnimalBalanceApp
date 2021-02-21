using AnimalBalanceApp.Core.Entities;
using System;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IAuthorizeService
    {
        Task<(string, string)> AuthenticateUser(UserLogin login);
        Task<bool> CreateUser(Security security);
    }
}