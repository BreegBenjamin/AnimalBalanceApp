using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Exceptions;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Core.Properties;
using AnimalBalanceApp.Core.QueryFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Services.Logic
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordService _passwordService;
        public UserService(IUnitOfWork unitOfWork, IPasswordService passwordService)
        {
            _unitOfWork = unitOfWork;
            _passwordService = passwordService;
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
        public async Task<User> GetUserById(int userId) 
        {
            var userResut = await _unitOfWork.UserRepository.GetById(userId);
            if (userResut == null)
                throw new BusinessException(AppMessages.UserNotExists);
            return userResut;
        }
        public async Task<ApiMessages> InsertUser(User user)
        {
            var messageResult = new ApiMessages();
            try
            {
                user.UserType = 2;
                user.IsActive = 1;
                user.UserPassword = _passwordService.Hash(user.UserPassword);
                await _unitOfWork.UserRepository.Add(user);
                messageResult.Status = await _unitOfWork.SaveChangedAsync();
                messageResult.Message = AppMessages.RegisterUser;
            }
            catch (Exception ex)
            {
                messageResult.Message = ex.Message;
                messageResult.Status = false;
            }
            return messageResult;
        }
        public async Task<ApiMessages> DeleteUser(int userId)
        { 
            try
            {
                var usu = await _unitOfWork.UserRepository.GetById(userId);
                if (usu == null)
                    return _generateResponse(false, AppMessages.UserNotExists);
                else 
                {
                    await _unitOfWork.UserRepository.Delete(userId);
                    return _generateResponse(true, AppMessages.UserUpdateSuccess);
                }
            }
            catch (Exception ex)
            {
                return _generateResponse(false, ex.Message);
            }
        }
        public async Task<ApiMessages> UpdateUser(User user)
        {
            var existingUser = await _unitOfWork.UserRepository.GetById(user.Id);
            if (existingUser == null)
                return _generateResponse(false, AppMessages.UserNotExists);
            else
            {
                existingUser.Birthdate = (user.Birthdate != DateTime.MinValue) ? user.Birthdate : existingUser.Birthdate;
                existingUser.Email = _getProperty(user.Email, existingUser.Email);
                existingUser.LastName = _getProperty(user.LastName, existingUser.LastName);
                existingUser.Telephone = _getProperty(user.Telephone,existingUser.Telephone);
                existingUser.UserName = _getProperty(user.UserName, existingUser.UserName);
                _unitOfWork.UserRepository.Update(existingUser);
                return _generateResponse(true, AppMessages.UserUpdateSuccess);
            }
        }
        public async Task<ApiMessages> UpdatePassword(int id, string password)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetById(id);
                if (user == null)
                    return _generateResponse(false, AppMessages.UserNotExists);
                bool result = _passwordService.Check(user.UserPassword, password);
                if (result)
                {
                    user.UserPassword = _passwordService.Hash(password);
                    _unitOfWork.UserRepository.Update(user);
                    return _generateResponse(true, AppMessages.PasswordUpdateSuccess);
                }
                else
                    return _generateResponse(false, AppMessages.PasswordNotMatch);
            }
            catch (Exception ex)
            {
                return _generateResponse(false, ex.Message);
            }

        }
        private ApiMessages _generateResponse(bool status, string message) 
            => new ApiMessages { Message = message, Status = status };
        private string _getProperty(string newValue, string oldValue)
            => !string.IsNullOrEmpty(newValue) ? newValue : oldValue;
    }
}