using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Core.Properties;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Services.Logic
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly ISecurityService _securityService;
        private readonly IPasswordService _passwordService;
        private readonly AuthenticationOptions _authenticationOptions;

        public AuthorizeService(ISecurityService securityService,
                                IOptions<AuthenticationOptions> options, 
                                IPasswordService passwordService)
        {
            _securityService = securityService;
            _authenticationOptions = options.Value;
            _passwordService = passwordService;
        }
        public async Task<(string, string)> AuthenticateUser(UserLogin login) 
        {
            var validInfo = await _isValidUser(login);
            if (validInfo.Item1)
            {
                string token = _generateToken(validInfo.Item2);
                return (token, _authenticationOptions.ExpireTokenText);
            }
            else
                return (AppMessages.InvalidCredencial, AppMessages.NumberMinutosToken);
        }
        public async Task<bool> CreateUser(Security security)
            => await _securityService.RegisterUser(security);
        private async Task<Tuple<bool, Security>> _isValidUser(UserLogin login) 
        {
            bool isValid = false;
            Security user = await _securityService.GetLoginByCredentials(login);
            if(user != null)
                isValid = _passwordService.Check(user.UserPassword, login.Password);
            var tupleResult = new Tuple<bool, Security>(isValid, user );
            return tupleResult;
        }
        private string _generateToken(Security security)
        {
            //header
            var symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurity, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //claims
            var claims = new Claim[] 
            {
                new Claim(ClaimTypes.Name, security.UserName),
                new Claim("User", security.SecurityUser),
                new Claim(ClaimTypes.Role, security.UserRol.ToString())
            };
            //payload
            var payload = new JwtPayload(
                issuer: _authenticationOptions.Issuer,
                audience: _authenticationOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires : DateTime.UtcNow.AddMinutes(_authenticationOptions.ExpiresToken)

            );
            //sereialización dekl Token
            string tokenSerialize = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(header, payload));

            return tokenSerialize;
        }
    }
}
