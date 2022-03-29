using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NegociaFacil.Domain.Identity;

namespace NegociaFacil.Infra.Data.DBContext
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                        .HasData(new IdentityRole { Name = CustomRoles.Admin, NormalizedName = CustomRoles.Admin.ToUpper() });

            modelBuilder.Entity<IdentityRole>()
                        .HasData(new IdentityRole { Name = CustomRoles.User, NormalizedName = CustomRoles.User.ToUpper() });

            base.OnModelCreating(modelBuilder);
        }
    }
}
