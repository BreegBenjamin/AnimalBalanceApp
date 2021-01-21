using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Infrastructure.Data;
using AnimalBalanceApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using FluentValidation.AspNetCore;
using AnimalBalanceApp.Infrastructure.Filters;
using AnimalBalanceApp.Core.Services.Logic;

namespace AnimalBalanceApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnimalBalanceApp.Api", Version = "v1" });
            });
            services.AddControllers(option=> 
            {
                option.Filters.Add<GlobalExceptionFilter>();
            })
            .AddNewtonsoftJson(opts=> 
            {
                opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            //Register Repositorys
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseSocialRepository<>));
            //Register DB Context
            services.AddDbContext<AnimalBalanceAppContext>(db => 
            {
                db.UseSqlServer(Configuration.GetConnectionString("AnimalBalanceDB"));
            });
            //Register Mapping
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Register Validators
            services.AddMvc(opts=> opts.Filters.Add<ValidationFilter>())
            .AddFluentValidation(options=> 
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
            //Register services
            services.AddTransient<IPostService, PostService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimalBalanceApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
