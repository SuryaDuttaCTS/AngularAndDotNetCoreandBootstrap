using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Context
{
    public class authDbContext: IdentityDbContext
    {
        public authDbContext(DbContextOptions<authDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "28d65a5b-a7db-4850-b380-83591f7d7531";
            var writerRoleId = "9740f16c-24a1-4224-a7be-1bb00b7c6892";

            // Create Reader and Writer Role
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId
                }
            };

            // Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);


            // Create an Admin User
            var adminUserId = "edc267ec-d43c-4e3b-8108-a1a1f819906d";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@codepulse.com",
                Email = "admin@codepulse.com",
                NormalizedEmail = "admin@codepulse.com".ToUpper(),
                NormalizedUserName = "admin@codepulse.com".ToUpper(),
                ConcurrencyStamp = "d627c58e-4ede-4bed-9d14-ce5f3485df9d",
                SecurityStamp = "2c76eac4-655e-4fd5-81d4-4f59c2f353e5"

            };

            admin.PasswordHash = "AQAAAAEAACcQAAAAEKCdTdvRwAGyJrZ45JcQJkqD13Gb0RzJ1fVRmpmXCrfCgFLx3T4Y9AwcJqP8k2F3Mg==";

            builder.Entity<IdentityUser>().HasData(admin);

            // Give Roles To Admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }

    }
}
