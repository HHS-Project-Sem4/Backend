using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.entities;

[Table("Product")] 
public class Product {
    
    [Key] [Column("PRODUCT_id")] public int productId { get; set; }

    [Column("PRODUCT_name")] public string name { get; set; }

    [Column("PRODUCT_category")] public string? category { get; set; }

    [Column("PRODUCT_sub_category")] public string? subCategory { get; set; }

    [Column("PRODUCT_colour")] public string? colour { get; set; }

    [Column("PRODUCT_prod_cost")] public double productionCost { get; set; }

    [Column("PRODUCT_storage_quantity")] public int storageQuantity { get; set; }

    public List<Order_Details>? orders { get; set; }  = null;
}