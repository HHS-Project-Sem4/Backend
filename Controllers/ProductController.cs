using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController
{
    /*public class ProductController(dbContext _context)
    {
        context = _context;
    }*/

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> getProductByID(int id)
    {

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> getAllProducts()
    {

    }

    [HttpGet("cost/{id}")]
    public async Task<ActionResult<int>> getProductionCostByID(int id)
    {
        
    }

    [HttpGet("type/{type}")]
    public async Task<ActionResult<IEnumerable<Product>>> getProductsByType(int type)
    {
        
    }
}