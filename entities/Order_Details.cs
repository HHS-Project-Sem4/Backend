public class Order_Details {
    public int number { get; set; }
    public int quantity { get; set; }
    public int unit_price { get; set; }

    public Day date { get; set; }
    public Medewerker? medewerker { get; set; }
    public Customer? klant { get; set; }
    public Product? product { get; set; }
}