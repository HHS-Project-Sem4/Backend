public class Order_Details {
    public int ORDER_DETAIL_id { get; set; }
    public int ORDER_HEADER_id { get; set; }
    public int ORDER_DETAIL_order_quantity { get; set; }
    public int ORDER_DETAIL_unit_price { get; set; }

    public DateTime DAY_date_ { get; set; }
    public int DAY_MONTH_nr { get; set; }
    public int DAY_QUARTER_nr { get; set; }
    public int DAY_YEAR_nr { get; set; }
    public Order_Date DAY_date { get; set; }
    public Employee? EMPLOYEE_id { get; set; }
    public Customer? CUSTOMER_id { get; set; }
    public Product? PRODUCT_id { get; set; }
}