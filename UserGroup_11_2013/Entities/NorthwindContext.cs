using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace UserGroup.Entities
{
public class NorthwindContext : DbContext
{
    // Use the constructor to target a specific named connection string
    public NorthwindContext()
        : base("name=DefaultConnection")
    {
        // Disable proxy creation as this messes up the data service.
        this.Configuration.ProxyCreationEnabled = false;

        // Create Northwind if it doesn't already exist.
        this.Database.CreateIfNotExists();
    }

    // Disable creation of the EdmMetadata table.
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
}
}
    