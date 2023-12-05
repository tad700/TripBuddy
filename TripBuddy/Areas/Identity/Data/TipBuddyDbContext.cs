using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using TripBuddy.Areas.Identity.Data;

namespace TripBuddy.Areas.Identity.Data;

public class TipBuddyDbContext : IdentityDbContext<TripBuddyUser>
{
  
    private string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Todor\\Documents\\TripBuddyDB.mdf;Integrated Security=True;Connect Timeout=30";

    public TipBuddyDbContext(DbContextOptions<TipBuddyDbContext> options)
        : base(options)
    {

    }

    public DbSet<Trip>? Trips { get; set; }
    public DbSet<Car>? Cars { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
        optionsBuilder.UseSqlServer(connString);
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    
    }
   
}

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<TripBuddyUser>
{
    void IEntityTypeConfiguration<TripBuddyUser>.Configure(EntityTypeBuilder<TripBuddyUser> builder)
    {
        builder.Property(u=>u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
       

    }

}