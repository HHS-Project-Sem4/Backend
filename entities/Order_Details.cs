public class Order_Details {
    public int number { get; set; }
    public int quantity { get; set; }
    public int unit_price { get; set; }

    public Day date { get; set; }

    public int medewerker_id { get; set; }
    public Medewerker medewerker { get; set; }
    public int klant_id { get; set; }
    public Customer klant { get; set; }
    public int product_id { get; set; }
    public Product product { get; set; }
}