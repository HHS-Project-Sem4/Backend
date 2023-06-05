using Backend.entities;
using Microsoft.EntityFrameworkCore;

public class outdoorFusionContext : DbContext
{
    public outdoorFusionContext(DbContextOptions<outdoorFusionContext> options)
    : base(options)
    {
    }

    public DbSet<Product> Product { get; set; } = default!;
    public DbSet<Customer> Customer { get; set; } = default!;
    public DbSet<Employee> Medewerker { get; set; } = default!;
    public DbSet<Order_Date> Day { get; set; } = default!;
    public DbSet<Order_Details> Order_Details { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=outdoorfusionserver.database.windows.net;Database=OutdoorFusion;User Id=floep;Password=WaaromWilDePausNietGecremeerdWorden?HijLeeftNog;");
    }

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .ToTable("Product");

        builder.Entity<Product>()
            .HasKey(product => product.ProductId);

        builder.Entity<Customer>()
            .ToTable("Customer");

        builder.Entity<Customer>()
            .HasKey(customer => customer.CUSTOMER_id);

        builder.Entity<Employee>()
            .ToTable("Medewerker");

        builder.Entity<Employee>()
            .HasKey(medewerker => medewerker.EMPLOYEE_id);

        builder.Entity<Order_Date>()
            .ToTable("Day");
        
        builder.Entity<Order_Date>()
            .HasKey(order_date => new { order_date.DAY_date, order_date.DAY_MONTH_nr , order_date.DAY_QUARTER_nr , order_date.DAY_YEAR_nr});

        builder.Entity<Order_Details>()
            .ToTable("Order_Details");

        builder.Entity<Order_Details>()
            .HasKey(order_Details => order_Details.ORDER_DETAIL_id);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.EMPLOYEE_id)
            .WithMany(medewerker => medewerker.EMPLOYEE_orders);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.CUSTOMER_id)
            .WithMany(klant => klant.CUSTOMER_orders);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.PRODUCT_id)
            .WithMany(product => product.PRODUCT_orders);

 
        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.DAY_date)
            .WithOne(day => day.DAY_order)
            .HasForeignKey<Order_Details>(order_Details => new { order_Details.DAY_date_, order_Details.DAY_MONTH_nr , order_Details.DAY_QUARTER_nr , order_Details.DAY_YEAR_nr});
    }
}