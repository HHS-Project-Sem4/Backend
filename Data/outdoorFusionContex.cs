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

        builder.Entity<Product>()
            .HasKey(product => product.id);

        builder.Entity<Customer>()
            .ToTable("Customer");

        builder.Entity<Customer>()
            .HasKey(customer => customer.id);

        builder.Entity<Medewerker>()
            .ToTable("Medewerker");

        builder.Entity<Medewerker>()
            .HasKey(medewerker => medewerker.id);

        builder.Entity<Day>()
            .ToTable("Day");
        
        //builder.Entity<Day>()
        //.HasKey(day => day.id);

        builder.Entity<Order_Details>()
            .ToTable("Order_Details");

        builder.Entity<Order_Details>()
            .HasKey(order_Details => order_Details.number);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.medewerker)
            .WithMany(medewerker => medewerker.orders);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.klant)
            .WithMany(klant => klant.orders);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.product)
            .WithMany(product => product.orders);

        // iets met dat doen
        //builder.Entity<Order_Details>()
        //    .HasOne(order_Details => order_Details.medewerker)
        //    .WithMany(medewerker => medewerker.orders);
    }
}