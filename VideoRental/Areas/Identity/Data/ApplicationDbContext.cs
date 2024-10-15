using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebMvcPruebaMosh.Areas.Identity.Data;
using WebMvcPruebaMosh.Models;

namespace WebMvcPruebaMosh.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movies> Movies { get; set; }
    public DbSet<MembershipTypes> MembershipTypes { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Rental> Rental { get; set; }

}

