using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CinemaWPF.Logic.Interfaces;
using CinemaWPF.Logic.Services;
using CinemaWPF.Models;
using CinemaWPF.Repository;
using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Repository.Repositories;

namespace CinemaWPF.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<CinemaDbContext>();

            services.AddTransient<ISeatRepository, BrandRepository>();
            services.AddTransient<IReserveRepository, ReserveRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();

            services.AddTransient<IReverseLogic, SeatLogic>();
            services.AddTransient<ICarLogic, ReserveLogic>();
            services.AddTransient<IOwnerLogic, OwnerLogic>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
