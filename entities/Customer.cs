public class Customer {
    public int CUSTOMER_id { get; set; }
    public string CUSTOMER_address { get; set; }
    public string CUSTOMER_city { get; set; }
    public string CUSTOMER_state { get; set; }
    public string CUSTOMER_region { get; set; }
    public string CUSTOMER_country { get; set; }
    public string CUSTOMER_company_name { get; set; }
    public List<Order_Details>? CUSTOMER_orders { get; set; }  = null;
}