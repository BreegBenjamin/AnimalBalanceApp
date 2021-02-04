using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Exceptions;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Core.QueryFilter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Services.Logic
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetUsers(UserQueryFilter filters) 
        {
            var users = _unitOfWork.UserRepository.GetAll();
            if (filters.GetIsActive)
                users = users.Where(x => x.IsActive == 1);
            else if (filters.GetNotActive)
                users = users.Where(x => x.IsActive == 0);
            return users;
        }
        public async Task<bool> InsertUser(User user)
        {
            user.UserType = 2;
            user.IsActive = 1;
            await _unitOfWork.UserRepository.Add(user);
            return await _unitOfWork.SaveChangedAsync();
        }
        public async Task<User> GetUserForId(int userId) 
        {
            var userResut = await _unitOfWork.UserRepository.GetById(userId);
            if (userResut == null)
                throw new BusinessException("El usuario consultado no existe");
            else if (userResut.IsActive == 0)
                throw new BusinessException("El usuario consulatado no está activo");
            return userResut;
        }
    }
}
