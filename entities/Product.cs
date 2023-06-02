public class Product {
    public int id { get; set; }
    public string name { get; set; }
    public int category { get; set; }
    public int sub_category { get; set; }
    public string colour { get; set; }
    public float price { get; set; }
    public int voorraad { get; set; }
    public List<Order_Details>? orders { get; set; }  = null;
}