using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeakerMeet.Models;
using SpeakerMeet.Repositories;
using SpeakerMeet.Repositories.Interfaces;
using SpeakerMeet.Services;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.API
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<SpeakerMeetContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton(typeof(DbContext), typeof(SpeakerMeetContext));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ISpeakerService, SpeakerService>();
            services.AddTransient<IGravatarService, GravatarService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
