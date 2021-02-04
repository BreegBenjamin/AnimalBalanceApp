using AnimalBalanceApp.Api.Responses;
using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Enumerations;
using AnimalBalanceApp.Core.Exceptions;
using AnimalBalanceApp.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizeService _authorizationService;
        private readonly IMapper _mapper;
        public AuthorizationController(IAuthorizeService authorizationService, IMapper mapper)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            string token = await _authorizationService.AuthenticateUser(login);
            var response = new ApiResponse<string>(token);
            return Ok(response);
        }

        [Authorize(Roles = nameof(RoleType.Administrator))]
        [HttpPost ]
        public async Task<IActionResult> PostUser(SecurityDto securityDto) 
        {
            var security = _mapper.Map<Security>(securityDto);
            var response = await _authorizationService.CreateUser(security);
            return Ok(response);
        }
    }
}