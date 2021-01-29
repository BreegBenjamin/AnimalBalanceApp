using AnimalBalanceApp.Api.Responses;
using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Exceptions;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Core.QueryFilter;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Api.Controllers
{
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
        public IActionResult GetUsers([FromQuery] UserQueryFilter filters) 
        {
            var user = _userService.GetUsers(filters);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(user);
            var response = new ApiResponse<IEnumerable<UserDto>>(usersDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser(UserDto userDto) 
        {
            if (userDto.Id > 0 || userDto.IsActive > 0 || userDto.UserType > 0)
                throw new ParameterException("El parametro de entrada esta herrado");
            var user = _mapper.Map<User>(userDto);
            bool result = await _userService.InsertUser(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
