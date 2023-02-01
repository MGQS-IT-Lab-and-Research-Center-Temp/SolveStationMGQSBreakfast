using MGQSBreakfast.Context;
using MGQSBreakfast.Contracts.Repositories;
using MGQSBreakfast.Contracts.Services;
using MGQSBreakfast.Implementation.Repositories;
using MGQSBreakfast.Implementation.Services;
using Microsoft.EntityFrameworkCore;

namespace MGQSBreakfast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));

            builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("ApplicationDbContext2")));

            builder.Services.AddTransient<IBreakfastRepository, BreakFastRepository>();
            builder.Services.AddTransient<IBreakfastService, BreakfastService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}