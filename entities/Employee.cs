using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.entities;

[Table("Employee")] 
public class Employee {
    [Key] [Column("EMPLOYEE_id")] public int employeeId { get; set; }
    [Column("EMPLOYEE_first_name")] public string? firstName { get; set; }
    [Column("EMPLOYEE_last_name")] public string? lastName { get; set; }
    [Column("EMPLOYEE_city")] public string? city { get; set; }
    [Column("EMPLOYEE_state")] public string? state { get; set; }
    [Column("EMPLOYEE_region")] public string? region { get; set; }
    [Column("EMPLOYEE_country")] public string? country { get; set; }
    public List<Order_Details>? orders { get; set; }  = null;
}