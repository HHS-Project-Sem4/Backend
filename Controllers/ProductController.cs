using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
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
        return null;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> getAllProducts()
    {
        return null;
    }

    [HttpGet("cost/{id}")]
    public async Task<ActionResult<int>> getProductionCostByID(int id)
    {
        return null;
    }

    [HttpGet("type/{type}")]
    public async Task<ActionResult<IEnumerable<Product>>> getProductsByType(int type)
    {
        return null;
    }
}