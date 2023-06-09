using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class VoorraadController : ControllerBase
{
    private readonly outdoorFusionContext context;
    public VoorraadController(outdoorFusionContext _context)
    {
        context = _context;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<int>> getSupplyByProduct(int id)
    {
        var product = context.Product.Find(id);
        return (product == null) ? StatusCode(404) : product.storageQuantity;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuantityType>>> getSupply()
    {
        var producten = context.Product.ToList();
        List<QuantityType> opslag = new List<QuantityType>();
        int i = 0;
        foreach (var product in producten)
        {
            QuantityType q = new QuantityType() {id = product.productId, quantity = product.storageQuantity};
            opslag.Add(q);
            i++;
        }
        return (opslag == null) ? StatusCode(04) : opslag;
    }
}