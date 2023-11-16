using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using MyCoolCompany.MyTestModule.Data.Models;
using VirtoCommerce.OrdersModule.Data.Model;
using VirtoCommerce.OrdersModule.Data.Repositories;

namespace MyCoolCompany.MyTestModule.Data.Repositories;

public class MyTestModuleDbContext : OrderDbContext
{

    public MyTestModuleDbContext(DbContextOptions<MyTestModuleDbContext> options)
        : base(options)
    {
    }

    protected MyTestModuleDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BlogEntity>().ToTable("Blogs").HasKey(x => x.Id);
        modelBuilder.Entity<BlogEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        modelBuilder.Entity<BlogEntity>().Property(x => x.Name).HasMaxLength(128);

        modelBuilder.Entity<CustomerOrderV2Entity>();

        //modelBuilder.Entity<MyTestModuleEntity>().ToTable("MyTestModule").HasKey(x => x.Id);
        //modelBuilder.Entity<MyTestModuleEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=sa;Password=123;Connect Timeout=30;TrustServerCertificate=True;");
        }

        base.OnConfiguring(optionsBuilder);
    }
}
