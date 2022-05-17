using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PeliculasAPI.Services;
using PeliculasCore.DataAccess;
using PeliculasCore.Helpers;
using PeliculasCore.Repositories;
using PeliculasCore.Services;

namespace PeliculasAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddEndpointsApiExplorer();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<GeneroRepository>();
            services.AddTransient<GeneroService>();
            services.AddTransient<ActorService>();
            services.AddTransient<ActorRepository>();
            services.AddTransient<MovieService>();
            services.AddTransient<MovieRepository>();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(mc => mc.AddProfile(new AutoMapperProfiles()));
            services.AddTransient<IFileStorageService, LocalStorageService>();

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
            //app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
