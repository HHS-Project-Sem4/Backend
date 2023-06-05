using Backend.entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly outdoorFusionContext context;
    public ProductController(outdoorFusionContext _context)
    {
        context = _context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> getProductByID(int id)
    {
        var product = context.Product.Find(id);
        return product;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> getAllProducts()
    {
        var producten = context.Product.ToList();
        return producten;
    }

    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<Product>>> getProductsByCategory(string category)
    {
        var producten = context.Product.ToList();
        var result = producten.FindAll(p => p.category == category);
        return result;
    }

    [HttpGet("subcategory/{subCategory}")]
    public async Task<ActionResult<IEnumerable<Product>>> getProductsBySubCategory(string subCategory)
    {
        var producten = context.Product.ToList();
        var result = producten.FindAll(p => p.subCategory == subCategory);
        return result;
    }
}