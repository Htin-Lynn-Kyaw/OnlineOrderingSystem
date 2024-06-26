using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineOrderingSystem.Models.Entities;

namespace OnlineOrderingSystem.Database;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var admin = new IdentityRole("admin");
        admin.NormalizedName = "Admin";

        var client = new IdentityRole("client");
        client.NormalizedName = "Client";

        //var seller = new IdentityRole("seller");
        //seller.NormalizedName = "Seller";

        builder.Entity<IdentityRole>().HasData(admin, client);

        builder.Entity<Restaurant>()
            .HasOne(r => r.Address)
            .WithOne(a => a.Restaurant)
            .HasForeignKey<Address>(a => a.AddressID);
        //.OnDelete(DeleteBehavior.Cascade);

        builder.Entity<AppUser>()
            .HasOne(u => u.Address)
            .WithOne(a => a.AppUser)
            .HasForeignKey<Address>(u => u.AddressID);

        builder.Entity<Category>()
            .HasOne(c => c.Restaurant)
            .WithMany(r => r.Categories)
            .HasForeignKey(c => c.RestaurantID);

        builder.Entity<MenuItem>()
            .HasOne(m => m.Category)
            .WithMany(c => c.MenuItems)
            .HasForeignKey(m => m.CategoryID);

        builder.Entity<OrderItem>()
            .HasOne(o => o.Order)
            .WithMany(oi => oi.OrderItems)
            .HasForeignKey(oi => oi.OrderID);

        builder.Entity<OrderItem>()
            .HasOne(mi => mi.MenuItem)
            .WithMany()
            .HasForeignKey(mi => mi.MenuItemID);

        builder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey(o => o.UserID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Order>()
            .HasOne(o => o.Restaurant)
            .WithMany()
            .HasForeignKey(o => o.RestaurantID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
