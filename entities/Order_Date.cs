using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.entities;

[Table("Order_Date")] 
public class Order_Date {
    [Column("DAY_date")] public DateTime date { get; set; }
    [Column("DAY_MONTH_nr")] public int monthNr { get; set; }
    [Column("DAY_QUARTER_nr")] public int quarterNr { get; set; }
    [Column("DAY_YEAR_nr")] public int yearNr { get; set; }
    public Order_Details? order { get; set; }
}