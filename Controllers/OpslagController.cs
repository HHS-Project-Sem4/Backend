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
        var product = context.Product.Find(id);
        return product.storageQuantity;
    }

    ////////////////////////////////////////////
    //
    //
    // is deze nog wel nodig???
    //
    //
    ///////////////////////////////////////////
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
        return opslag;
    }
    public class QuantityType
    {
        public int id {get; set;}
        public int quantity {get; set;}
    }
}