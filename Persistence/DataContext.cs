using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define UserActivities keys 
            builder.Entity<UserActivity>(x => x.HasKey(ua => new { ua.AppUserId, ua.ActivityId }));

            builder.Entity<UserActivity>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.UserActivities)
                .HasForeignKey(u => u.AppUserId);

            builder.Entity<UserActivity>()
            .HasOne(u => u.Activity)
            .WithMany(u => u.UserActivities)
            .HasForeignKey(a => a.ActivityId);

            // Is this below needed ?????? or only for many to many tables like the one for useractivity
            builder.Entity<Property>()
                .HasOne(p=>p.PropertyType);

            builder.Entity<Property>()
                .HasMany(p=>p.PropertyImages)
                .WithOne(i => i.Property)
                .HasForeignKey(p => p.PropertyId);                            
        }
    }
}
