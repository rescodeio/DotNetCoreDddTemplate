using Data;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddScoped(typeof(IJobRepository), typeof(JobRepository));
            
            services.AddScoped(typeof(JobType), defaultJobType => JobType.Batch );
            services.AddScoped(typeof(JobFactory));
            services.AddScoped(typeof(IGetJobReport), typeof(GetJobReport));
            services.AddScoped(typeof(IGetJobState), typeof(GetJobState));
            services.AddScoped(typeof(ICreateJob), typeof(CreateJob));

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
