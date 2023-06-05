using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class PredictionController : ControllerBase
{
    private readonly outdoorFusionContext context;
    public PredictionController(outdoorFusionContext _context)
    {
        context = _context;
    }

    [HttpGet("voorraad")]
    public async Task<ActionResult<IEnumerable<int[,]>>> predictVoorraad()
    {
        return null;
    }

    [HttpGet("sales")]
    public async Task<ActionResult<IEnumerable<int[,]>>> predictSales()
    {
        return null;
    }

    [HttpGet("sales/season/{quarter}")]
    public async Task<ActionResult<IEnumerable<int[,]>>> predictSalesPerSeason(int quarter)
    {
        return null;
    }

    [HttpGet("sales/year/{year}")]
    public async Task<ActionResult<IEnumerable<int[,]>>> predictSalesPerYear(int year)
    {
        return null;
    }
}