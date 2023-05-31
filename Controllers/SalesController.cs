using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/verkoop")]
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

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSales()
    {

    }

    [HttpGet("product/{id}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByProduct(int id)
    {

    }

    [HttpGet("customer/{id}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByCustomer(int id)
    {

    }

    [HttpGet("filiaal/{id}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByFiliaal(int id)
    {

    }
}