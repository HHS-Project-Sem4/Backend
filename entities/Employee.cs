public class Employee {
    public int EMPLOYEE_id { get; set; }
    public string EMPLOYEE_first_name { get; set; }
    public string EMPLOYEE_last_name { get; set; }
    public string EMPLOYEE_city { get; set; }
    public string EMPLOYEE_state { get; set; }
    public string EMPLOYEE_region { get; set; }
    public string EMPLOYEE_country { get; set; }
    public List<Order_Details>? EMPLOYEE_orders { get; set; }  = null;
}