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
            .HasKey(product => product.productId);

        builder.Entity<Customer>()
            .ToTable("Customer");

        builder.Entity<Customer>()
            .HasKey(customer => customer.customerId);

        builder.Entity<Employee>()
            .ToTable("Medewerker");

        builder.Entity<Employee>()
            .HasKey(medewerker => medewerker.employeeId);

        builder.Entity<Order_Date>()
            .ToTable("Day");
        
        builder.Entity<Order_Date>()
            .HasKey(order_date => new { order_date.date, order_date.monthNr , order_date.quarterNr , order_date.yearNr});

        builder.Entity<Order_Details>()
            .ToTable("Order_Details");

        builder.Entity<Order_Details>()
            .HasKey(order_Details => order_Details.orderDetailId);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.employee)
            .WithMany(medewerker => medewerker.orders);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.customer)
            .WithMany(klant => klant.orders);

        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.product)
            .WithMany(product => product.orders);

 
        builder.Entity<Order_Details>()
            .HasOne(order_Details => order_Details.day)
            .WithOne(day => day.order)
            .HasForeignKey<Order_Details>(order_Details => new { order_Details.date, order_Details.monthNr , order_Details.quarterNr , order_Details.yearNr});
    }
}