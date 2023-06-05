using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.entities;

[Table("Customer")] 
public class Customer {
    [Key] [Column("CUSTOMER_id")] public int customerId { get; set; }
    [Column("CUSTOMER_address")] public string address { get; set; }
    [Column("CUSTOMER_city")] public string city { get; set; }
    [Column("CUSTOMER_state")] public string state { get; set; }
    [Column("CUSTOMER_region")] public string region { get; set; }
    [Column("CUSTOMER_country")] public string country { get; set; }
    [Column("CUSTOMER_company_name")] public string companyName { get; set; }
    public List<Order_Details>? orders { get; set; }  = null;
}