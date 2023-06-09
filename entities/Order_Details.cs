using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Backend.entities;

[Table("Order_Details")] 
public class Order_Details {
    [Key] [Column("ORDER_DETAIL_id")] public int orderDetailId { get; set; }
    [Column("ORDER_HEADER_id")]public int orderHeaderId { get; set; }
    [Column("ORDER_DETAIL_order_quantity")]public int orderQuantity { get; set; }
    [Column("ORDER_DETAIL_unit_price")]public double unitPrice { get; set; }

    [Column("Day_date")]public DateTime day { get; set; }
    [Column("EMPLOYEE_id")]public int? employeeId { get; set; }
    public Employee? employee { get; set; }
    [Column("CUSTOMER_id")]public int? customerId { get; set; }
    public Customer? customer { get; set; }
    [Column("PRODUCT_id")]public int? productId { get; set; }
    public Product? product { get; set; }
}