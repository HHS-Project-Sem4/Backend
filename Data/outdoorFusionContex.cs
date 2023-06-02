using Microsoft.EntityFrameworkCore;

public class outdoorFusionContext : DbContext
{
    public outdoorFusionContext(DbContextOptions<outdoorFusionContext> options)
    : base(options)
    {
    }

    public DbSet<Product> Product { get; set; } = default!;
    public DbSet<Customer> Customer { get; set; } = default!;
    public DbSet<Medewerker> Medewerker { get; set; } = default!; 
    public DbSet<Day> Day { get; set; } = default!;
    public DbSet<Order_Details> Order_Details { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .ToTable("Product");

        builder.Entity<Customer>()
            .ToTable("Customer");

        builder.Entity<Medewerker>()
            .ToTable("Medewerker");

        builder.Entity<Day>()
            .ToTable("Day");

        builder.Entity<Order_Details>()
            .ToTable("Order_Details");
        
    }
}