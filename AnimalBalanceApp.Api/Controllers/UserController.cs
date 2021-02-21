using AnimalBalanceApp.Api.Responses;
using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Exceptions;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Core.Properties;
using AnimalBalanceApp.Core.QueryFilter;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(ApiResponse<IEnumerable<UserDto>>))]
        public IActionResult GetUsers([FromQuery] UserQueryFilter filters) 
        {
            var user = _userService.GetUsers(filters);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(user);
            var response = new ApiResponse<IEnumerable<UserDto>>(usersDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(ApiResponse<ApiMessages>))]
        public async Task<IActionResult> InsertUser(UserDto userDto) 
        {
            if (userDto.Id > 0 || userDto.IsActive > 0 || userDto.UserType > 0)
                throw new ParameterException(AppMessages.MessageParameter);
            var user = _mapper.Map<User>(userDto);
            var result = await _userService.InsertUser(user);
            var response = new ApiResponse<ApiMessages>(result);
            return Ok(response);
        }

        [HttpGet("{idUser}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(ApiResponse<UserDto>))]
        public async Task<IActionResult> GetUserById(int idUser) 
        {
            if (idUser <= 0)
                return BadRequest("Id invalido");
            var user = await _userService.GetUserById(idUser);
            var userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpDelete("{idUser}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(ApiResponse<ApiMessages>))]
        public async Task<IActionResult> DeleteUser(int idUser) 
        {
            if (idUser <= 0)
                return BadRequest("Id invalido");
            var response = await _userService.DeleteUser(idUser);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(ApiResponse<ApiMessages>))]
        public async Task<IActionResult> UpdateUserData(UserDto userDto) 
        {
            var user = _mapper.Map<User>(userDto);
            var response = await _userService.UpdateUser(user);
            return Ok(response);
        }

        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(ApiResponse<ApiMessages>))]
        public async Task<IActionResult> UpdateUserPassword(int idUser, string password) 
        {
            if (idUser <= 0 || string.IsNullOrEmpty(password))
                return BadRequest("Los parametros estan errados");
            var response = await _userService.UpdatePassword(idUser, password);
            return Ok(response);
        }
    }
}