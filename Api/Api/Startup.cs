using System;
using System.Collections.Generic;
using System.Linq;
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
