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
        return (product == null) ? StatusCode(404) : product;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> getAllProducts()
    {
        var producten = context.Product.ToList();
        return (producten == null) ? StatusCode(404) : producten;
    }

    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<Product>>> getProductsByCategory(string category)
    {
        var producten = context.Product.ToList();
        var result = producten.FindAll(p => p.category == category);
        return (result == null) ? StatusCode(404) : result;
    }

    [HttpGet("categories")]
    public async Task<IEnumerable<string>> getAllCategories()
    {
        var producten = context.Product.ToList();
        var cats = producten.Select(p => p.category).Distinct();

        return cats;
    }


    [HttpGet("subcategory/{subCategory}")]
    public async Task<ActionResult<IEnumerable<Product>>> getProductsBySubCategory(string subCategory)
    {
        var producten = context.Product.ToList();
        var result = producten.FindAll(p => p.subCategory == subCategory);
        return (result == null) ? StatusCode(404) : result;
    }

    [HttpGet("subcategories")]
    public async Task<IEnumerable<string>> getAllSubCategories()
    {
        var producten = context.Product.ToList();
        var cats = producten.Select(p => p.subCategory).Distinct();

        return cats;
    }
}