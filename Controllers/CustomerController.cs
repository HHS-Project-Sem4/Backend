using Backend.entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly outdoorFusionContext context;
    public CustomerController(outdoorFusionContext _context)
    {
        context = _context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> getCustomers()
    {
        var customers = context.Customer.ToList();
        return customers;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> getCustomer(int id)
    {
        var customer = context.Customer.Find(id);
        return customer;
    }

    //zoals: 1,01-01-1997X31-12-1997
    [HttpGet("growthCustomerSales/{idDates}")]
    public async Task<ActionResult<IEnumerable<string>>> getSalesGrowthPerCustomer(string idDates)
    {
        var split = idDates.Split(",");
        var dates = Functionality.splitDates(split[1]);
        var id = Int32.Parse(split[0]);
        var sales = context.Order_Details.Where(o => o.day >= dates[0] && o.day <= dates[1]).Where(o => o.customerId == id).ToList();

        var salesPerMonth = new double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        foreach(Order_Details sale in sales)
        {
            salesPerMonth[sale.day.Month] += sale.orderQuantity;
        }
        var growthPerMonth = new string[12];
        var i = 0;
        foreach(float sale in salesPerMonth)
        {
            if(i != 12)
            growthPerMonth[i] = Functionality.calcGrowth(salesPerMonth[i], salesPerMonth[i + 1]).ToString();
            i++;
        }
        return growthPerMonth;
    }
}