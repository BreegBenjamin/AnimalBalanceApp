using AnimalBalanceApp.Api.Responses;
using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Enumerations;
using AnimalBalanceApp.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizeService _authorizationService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthorizationController(IAuthorizeService authorizationService, IMapper mapper, IConfiguration configuration)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost(nameof(GenerateToken))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(ApiResponse<string>))]
        public async Task<IActionResult> GenerateToken(UserLogin login)
        {
            var autResult = await _authorizationService.AuthenticateUser(login);
            string token = autResult.Item1;
            var metadata = new Metadata()
            {
                ExpiresToken = autResult.Item2
            };
            var response = new ApiResponse<string>(token) 
            {
                Meta = metadata
            };
            return Ok(response);
        }

        [Authorize(Roles = nameof(RoleType.Administrator))]
        [HttpPost(nameof(AddUserConsumer))]
        public async Task<IActionResult> AddUserConsumer(SecurityDto securityDto) 
        {
            var security = _mapper.Map<Security>(securityDto);
            var response = await _authorizationService.CreateUser(security);
            return Ok(response);
        }
    }
}