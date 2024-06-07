using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WinterWhispers.Data;
namespace WinterWhispers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("WinterWhispersContextConnection") ?? throw new InvalidOperationException("Connection string 'WinterWhispersContextConnection' not found.");

            builder.Services.AddDbContext<WinterWhispersContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<Areas.Identity.Data.WinterWhispersUser>(options => 
            options.SignIn.RequireConfirmedAccount = false) /*här slår vi av att vi behöver verifiera e-post*/
                .AddRoles<IdentityRole>() /*aktivera roller*/
                .AddEntityFrameworkStores<WinterWhispersContext>();


            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
