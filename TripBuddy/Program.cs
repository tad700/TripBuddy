using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TripBuddy.Areas.Identity.Data;
namespace TripBuddy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("TipBuddyDbContextConnection") ?? throw new InvalidOperationException("Connection string 'TipBuddyDbContextConnection' not found.");

            builder.Services.AddDbContext<TipBuddyDbContext>(options =>
options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<TripBuddyUser>(options => options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<TipBuddyDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "User" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<TripBuddyUser>>();

                string email = "adminAcc@admin.com";
                string password = "AdminAcc123.";


                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new TripBuddyUser();
                    user.FirstName = "ADMIN";
                    user.LastName = "1";

                    user.UserName = email;
                    user.Email = email;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");


                }


                app.Run();
            }
        }
    }
}