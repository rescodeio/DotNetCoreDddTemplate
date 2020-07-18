using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Services;
using Data;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        { 
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddScoped<IUserService, UserService>();
            
            
            services.AddDbContext<MyContext>(DataInstaller.Install(_env.IsDevelopment()));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            
            services.AddScoped(typeof(IDataInserter<MyContext>), typeof(EmptyInserter));
            services.AddScoped(typeof(IDataInserter<MyContext>), typeof(FakeInserter));
            
            services.AddScoped(typeof(ISomeService), typeof(ServiceOne));
            services.AddScoped(typeof(ISomeService), typeof(ServiceTwo));

            services.AddControllers();
            services.AddHealthChecks();
            services.AddOptions();
            services.AddMvc().AddControllersAsServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthcheck");
                endpoints.MapControllers();
            });
        }
    }
}
