using System;
using System.Threading;
using System.Threading.Tasks;

using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AutoCore.Data;

public sealed class AutoCoreDbContext : DbContext
{
    private const string SoftDeleteFilterName = "SoftDelete";

    public AutoCoreDbContext(DbContextOptions<AutoCoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<State> States => Set<State>();

    public DbSet<City> Cities => Set<City>();

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Supplier> Suppliers => Set<Supplier>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Module> Modules => Set<Module>();

    public DbSet<Option> Options => Set<Option>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();

    public DbSet<UnitType> UnitTypes => Set<UnitType>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<InventoryMovement> InventoryMovements => Set<InventoryMovement>();

    public DbSet<VehicleBrand> VehicleBrands => Set<VehicleBrand>();

    public DbSet<VehicleModel> VehicleModels => Set<VehicleModel>();

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public DbSet<Intake> Intakes => Set<Intake>();

    public DbSet<Service> Services => Set<Service>();

    public DbSet<Quote> Quotes => Set<Quote>();

    public DbSet<Process> Processes => Set<Process>();

    public DbSet<Instruction> Instructions => Set<Instruction>();

    public DbSet<ProcessDetail> ProcessDetails => Set<ProcessDetail>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<Sale> Sales => Set<Sale>();

    public DbSet<SaleDetail> SaleDetails => Set<SaleDetail>();

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ApplyAuditRules();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditRules();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("taller");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutoCoreDbContext).Assembly);

        modelBuilder.Entity<Customer>()
            .HasQueryFilter(SoftDeleteFilterName, customer => customer.DeletedAt == null);

        modelBuilder.Entity<Supplier>()
            .HasQueryFilter(SoftDeleteFilterName, supplier => supplier.DeletedAt == null);

        modelBuilder.Entity<Vehicle>()
            .HasQueryFilter(SoftDeleteFilterName, vehicle => vehicle.DeletedAt == null);

        modelBuilder.Entity<Product>()
            .HasQueryFilter(SoftDeleteFilterName, product => product.DeletedAt == null);

        modelBuilder.Entity<Employee>()
            .HasQueryFilter(SoftDeleteFilterName, employee => employee.DeletedAt == null);

        modelBuilder.Entity<User>()
            .HasQueryFilter(SoftDeleteFilterName, user => user.DeletedAt == null);
    }

    private void ApplyAuditRules()
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;

        foreach (EntityEntry entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not AuditableEntity auditable)
            {
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Added:
                    auditable.CreatedAt = now;
                    auditable.UpdatedAt = null;
                    break;

                case EntityState.Modified:
                    auditable.UpdatedAt = now;
                    break;

                case EntityState.Deleted when auditable is SoftDeletableEntity softDeletable:
                    entry.State = EntityState.Modified;
                    softDeletable.DeletedAt = now;
                    softDeletable.UpdatedAt = now;
                    break;
            }
        }
    }
}