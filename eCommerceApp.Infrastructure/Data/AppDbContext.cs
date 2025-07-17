using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Cart;
using eCommerceApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace eCommerceApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Achieve> CheckoutAchieves { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<PaymentMethod>()
                .HasData(
                    new PaymentMethod
                    {
                        Id = Guid.Parse("f5a43dbc-5c5d-4e77-bdbf-037f8f9dd10d"),
                        Name = "Credit Card"
                    }
                );
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Id = Guid.Parse("9e4f49fe-0786-44c6-9061-53d2aa84fab3").ToString(),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = Guid.Parse("3a9d0c3b-4e59-4b5e-a2b7-45c7d07f91d4").ToString(),
                        Name = "User",
                        NormalizedName = "USER"
                    }
                );
        }
    }
}
