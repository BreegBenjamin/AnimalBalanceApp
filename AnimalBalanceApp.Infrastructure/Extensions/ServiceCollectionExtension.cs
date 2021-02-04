using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Core.Services.Logic;
using AnimalBalanceApp.Infrastructure.Data;
using AnimalBalanceApp.Infrastructure.Interfaces;
using AnimalBalanceApp.Infrastructure.Options;
using AnimalBalanceApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AnimalBalanceApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            //Register DB Context
            services.AddDbContext<AnimalBalanceAppContext>(db =>
            {
                db.UseSqlServer(configuration.GetConnectionString("AnimalBalanceDB"));
            });
            return services;
        }
        public static IServiceCollection AddSettingsOptions(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IAuthorizeService, AuthorizeService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddSingleton<IUriService>(provaider =>
            {
                var accesor = provaider.GetRequiredService<IHttpContextAccessor>();
                HttpRequest request = accesor.HttpContext.Request;
                string absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
            return services;
        }
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"])),
                };
            });
            return services;
        }
    }
}
