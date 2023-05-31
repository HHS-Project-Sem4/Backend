using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/voorspel")]
[ApiController]
public class PredictionController
{
    /*public class PredictionController(dbContext _context)
    {
        context = _context;
    }*/

    [HttpGet("/voorraad")]
    public async Task<ActionResult<IEnumerable<int[,]>>> predictVoorraad()
    {

    }

    [HttpGet("/sales")]
    public async Task<ActionResult<IEnumerable<int[,]>>> predictSales()
    {

    }

    [HttpGet("/sales/season/{quarter}")]
    public async Task<ActionResult<IEnumerable<int[,]>>> predictSalesPerSeason(int quarter)
    {

    }

    [HttpGet("/sales/year/{year}")]
    public async Task<ActionResult<IEnumerable<int[,]>>> predictSalesPerYear(int year)
    {

    }
}