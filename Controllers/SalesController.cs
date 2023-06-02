using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class SalesController
{
    /*public class PredictionController(dbContext _context)
    {
        context = _context;
    }*/

    [HttpGet("date/{date}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByDate(string date)
    {
        return null;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSales()
    {
        return null;
    }

    [HttpGet("product/{id}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByProduct(int id)
    {
        return null;
    }

    [HttpGet("customer/{id}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByCustomer(int id)
    {
        return null;
    }

    [HttpGet("filiaal/{id}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByFiliaal(int id)
    {
        return null;
    }
}