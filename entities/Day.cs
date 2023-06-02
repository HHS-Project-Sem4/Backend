public class Day {
    public DateTime day { get; set; }
    public int month_nr { get; set; }
    public int quarter_nr { get; set; }
    public int year_nr { get; set; }
    public Order_Details? order { get; set; }
}