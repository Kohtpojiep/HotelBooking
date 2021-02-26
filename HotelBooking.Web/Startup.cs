using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Application;
using HotelBooking.DataAccess.MSSQL;
using HotelBooking.DataAccess.MSSQL.Repositories;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.IServices;
using MatBlazor;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DataAccessMappingProfile));

            //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            //services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IHotelService, HotelService>();
            
            services.AddTransient<IHotelImageRepository, HotelImageRepository>();
            services.AddTransient<IHotelImageService, HotelImageService>();

            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IRoomService, RoomService>();

            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IBookingService, BookingService>();

            services.AddTransient<IChequeRepository, ChequeRepository>();
            services.AddTransient<IChequeService, ChequeService>();

            //services.AddTransient<ICityRepository, CityRepository>();
            //services.AddTransient<ICityService, CityService>();

            services.AddDbContext<BookingHotelsContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("ConnectionDbContext")));

            services.AddMatBlazor();
            services.AddRazorPages();
            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
