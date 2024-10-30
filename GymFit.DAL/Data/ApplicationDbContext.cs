using GymFit.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymFit.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id= adminId, Name="Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = userId, Name = "User", NormalizedName = "USER" }
                );
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@gimfit.com",
                NormalizedUserName = "ADMIN@GYMFIT.COM",
                Email = "admin@gimfit.com",
                NormalizedEmail = "ADMIN@GYMFIT.COM",
                EmailConfirmed = true,
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser,"Admin!123");
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@gimfit.com",
                NormalizedUserName = "USER@GYMFIT.COM",
                Email = "user@gimfit.com",
                NormalizedEmail = "USER@GYMFIT.COM",
                EmailConfirmed = true,
            };
            user.PasswordHash = hasher.HashPassword(user, "User!123");
            builder.Entity<ApplicationUser>().HasData(adminUser,user);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminId, UserId = adminUser.Id},
                new IdentityUserRole<string> { RoleId = userId, UserId = user.Id }
                );
        }
        
        public DbSet<Service> services { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
    }
}
