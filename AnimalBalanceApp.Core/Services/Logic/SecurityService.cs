using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Services.Logic
{
    public class SecurityService : ISecurityService
    {

        private readonly IPasswordService _passwordService;
        private readonly IUnitOfWork _unitOfWork;
        public SecurityService(IUnitOfWork unitOfWork, IPasswordService passwordService)
        {
            _unitOfWork = unitOfWork;
            _passwordService = passwordService;
        }
        public async Task<Security> GetLoginByCredentials(UserLogin login) 
        {

            return await _unitOfWork.SecurityRepository.GetLoginByCredentials(login);
        }
        public async Task<bool> RegisterUser(Security security) 
        {
            security.UserPassword = _passwordService.Hash(security.UserPassword);

            await _unitOfWork.SecurityRepository.Add(security);
            return await _unitOfWork.SaveChangedAsync();
        }
    }
}