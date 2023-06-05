public class Product {
    public int PRODUCT_id { get; set; }
    public string? PRODUCT_name { get; set; }
    public string? PRODUCT_category { get; set; }
    public string? PRODUCT_sub_category { get; set; }
    public string? PRODUCT_colour { get; set; }
    public float PRODUCT_prod_cost { get; set; }
    public int PRODUCT_storage_quantity { get; set; }
    public List<Order_Details>? PRODUCT_orders { get; set; }  = null;
}