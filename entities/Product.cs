using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.entities;

[Table("Product")] 
public class Product {
    
    [Key] [Column("PRODUCT_id")] public int ProductId { get; set; }

    [Column("PRODUCT_name")] public string Name { get; set; }

    [Column("PRODUCT_category")] public string? Category { get; set; }

    [Column("PRODUCT_sub_category")] public string? SubCategory { get; set; }

    [Column("PRODUCT_colour")] public string? Colour { get; set; }

    [Column("PRODUCT_prod_cost")] public double ProductionCost { get; set; }

    [Column("PRODUCT_storage_quantity")] public int StorageQuantity { get; set; }

    public List<Order_Details>? PRODUCT_orders { get; set; }  = null;
}