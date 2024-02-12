using Microsoft.EntityFrameworkCore;
using SupplierManagement.Domain.Models;
using SupplierManagement.Extensions;

namespace SupplierManagement.Domain.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<Supplier> Suppliers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Supplier>().ToTable("suppliers");
        modelBuilder.Entity<Supplier>().HasKey(s => s.TaxIdentification);
        modelBuilder.Entity<Supplier>().Property(s => s.PhoneNumber).IsRequired();
        modelBuilder.Entity<Supplier>().Property(s => s.LastEditionDate).IsRequired();
        modelBuilder.Entity<Supplier>().Property(s => s.Address).IsRequired();
        modelBuilder.Entity<Supplier>().Property(s => s.Country).IsRequired();
        modelBuilder.Entity<Supplier>().Property(s => s.Tradename).IsRequired();
        modelBuilder.Entity<Supplier>().Property(s => s.BusinessName).IsRequired();
        modelBuilder.Entity<Supplier>().Property(s => s.AnnualBilling).IsRequired();
        modelBuilder.Entity<Supplier>().Property(s => s.Website).IsRequired();
        modelBuilder.Entity<Supplier>().Property(s => s.Email).IsRequired();
        
        modelBuilder.ApplySnakeCaseNamingConvention();
    }
}