using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class OpslagController : ControllerBase
{
    private readonly outdoorFusionContext context;
    public OpslagController(outdoorFusionContext _context)
    {
        context = _context;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<int>> getSupplyByProduct(int id)
    {
        return null;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<int[,]>>> getSupply()
    {
        return null;
    }
}