using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly outdoorFusionContext context;
    public SalesController(outdoorFusionContext _context)
    {
        context = _context;
    }

    // vul de dat string in als "15/06/1944X15/06/1945"
    [HttpGet("date/{date}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByDate(string date)
    {
        var dates = Functionality.splitDates(date);
        var sales = context.Order_Details.Where(o => o.day >= dates[0] && o.day <= dates[1]).ToList();
        return (sales == null) ? StatusCode(404) : sales;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSales()
    {
        var sales = context.Order_Details.ToList();
        return (sales == null) ? StatusCode(404) : sales;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order_Details>> getSale(int id)
    {
        var sale = context.Order_Details.Find(id);
        return (sale == null) ? StatusCode(404) : sale;
    }

    [HttpGet("product/{id}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByProduct(int id)
    {
        var sales = context.Order_Details.Where(o => o.productId == id).ToList();
        return (sales == null) ? StatusCode(404) : sales;
    }

    [HttpGet("customer/{id}")]
    public async Task<ActionResult<IEnumerable<Order_Details>>> getSalesByCustomer(int id)
    {
        var sales = context.Order_Details.Where(o => o.customerId == id).ToList();
        return (sales == null) ? StatusCode(404) : sales;
    }

    /////////////////////////////////////// NIET GEBRUIKEN DUURT TE LANG  
    //zoals: 01-01-1997X31-12-1997
    [HttpGet("growthSales/{datecode}")]
    public async Task<ActionResult<IEnumerable<string>>> getSalesGrowth(string datecode)
    {
        var dates = Functionality.splitDates(datecode);
        var sales = context.Order_Details.ToList();

        var salesPerMonth = new double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        foreach(Order_Details sale in sales)
        {
            salesPerMonth[sale.day.Month] += sale.orderQuantity;
        }
        var growthPerMonth = new string[12];
        var i = 0;
        foreach(float sale in salesPerMonth)
        {
            if(i != 12)
            growthPerMonth[i] = Functionality.calcGrowth(salesPerMonth[i], salesPerMonth[i + 1]).ToString();
            i++;
        }
        return growthPerMonth;
    }

    //zoals: 1,01-01-1997X31-12-1997
    [HttpGet("growthProductSales/{idDates}")]
    public async Task<ActionResult<IEnumerable<string>>> getSalesGrowthPerProduct(string idDates)
    {
        var split = idDates.Split(",");
        var dates = Functionality.splitDates(split[1]);
        var id = Int32.Parse(split[0]);
        var sales = context.Order_Details.Where(o => o.day >= dates[0] && o.day <= dates[1]).Where(o => o.productId == id).ToList();

        var salesPerMonth = new double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        foreach(Order_Details sale in sales)
        {
            salesPerMonth[sale.day.Month] += sale.orderQuantity;
        }
        var growthPerMonth = new string[12];
        var i = 0;
        foreach(float sale in salesPerMonth)
        {
            if(i != 12)
            growthPerMonth[i] = Functionality.calcGrowth(salesPerMonth[i], salesPerMonth[i + 1]).ToString();
            i++;
        }
        return growthPerMonth;
    }

    /////////////////////////////////////// NIET GEBRUIKEN DUURT TE LANG  
    //zoals: 01-01-1997X31-12-1997
    [HttpGet("growthWinst/{datecode}")]
    public async Task<ActionResult<IEnumerable<string>>> getWinstGrowth(string datecode)
    {
        var dates = Functionality.splitDates(datecode);
        var sales = context.Order_Details.ToList();

        var salesPerMonth = new double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        foreach(Order_Details sale in sales)
        {
            var product = context.Product.Find(sale.productId);
            if (product != null)
            salesPerMonth[sale.day.Month] += (sale.unitPrice - product.productionCost) * sale.orderQuantity;
        }
        var growthPerMonth = new string[12];
        var i = 0;
        foreach(float sale in salesPerMonth)
        {
            if(i != 12)
            growthPerMonth[i] = Functionality.calcGrowth(salesPerMonth[i], salesPerMonth[i + 1]).ToString();
            i++;
        }
        return growthPerMonth;
    }

    //zoals: 1,01-01-1997X31-12-1997
    [HttpGet("growthProductWinst/{idDates}")]
    public async Task<ActionResult<IEnumerable<string>>> getWinstGrowthPerProduct(string idDates)
    {
        var split = idDates.Split(",");
        var dates = Functionality.splitDates(split[1]);
        var id = Int32.Parse(split[0]);
        var sales = context.Order_Details.Where(o => o.day >= dates[0] && o.day <= dates[1]).Where(o => o.productId == id).ToList();
        var product = context.Product.Find(id);

        var salesPerMonth = new double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        foreach(Order_Details sale in sales)
        {
            if (product != null)
            salesPerMonth[sale.day.Month] += (sale.unitPrice - product.productionCost) * sale.orderQuantity;
        }
        var growthPerMonth = new string[12];
        var i = 0;
        foreach(float sale in salesPerMonth)
        {
            if(i != 12)
            growthPerMonth[i] = Functionality.calcGrowth(salesPerMonth[i], salesPerMonth[i + 1]).ToString();
            i++;
        }
        return growthPerMonth;
    }

    /////////////////////////////////////// NIET GEBRUIKEN DUURT TE LANG  
    //zoals: 01-01-1997X31-12-1997
    [HttpGet("growthKosten/{datecode}")]
    public async Task<ActionResult<IEnumerable<string>>> getKostenGrowth(string datecode)
    {
        var dates = Functionality.splitDates(datecode);
        var sales = context.Order_Details.ToList();

        var salesPerMonth = new double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        foreach(Order_Details sale in sales)
        {
            var product = context.Product.Find(sale.productId);
            if (product != null)
            salesPerMonth[sale.day.Month] += product.productionCost * sale.orderQuantity;
        }
        var growthPerMonth = new string[12];
        var i = 0;
        foreach(float sale in salesPerMonth)
        {
            if(i != 12)
            growthPerMonth[i] = Functionality.calcGrowth(salesPerMonth[i], salesPerMonth[i + 1]).ToString();
            i++;
        }
        return growthPerMonth;
    }

    //zoals: 1,01-01-1997X31-12-1997
    [HttpGet("growthProductKosten/{idDates}")]
    public async Task<ActionResult<IEnumerable<string>>> getKostenGrowthPerProduct(string idDates)
    {
        var split = idDates.Split(",");
        var dates = Functionality.splitDates(split[1]);
        var id = Int32.Parse(split[0]);
        var sales = context.Order_Details.Where(o => o.day >= dates[0] && o.day <= dates[1]).Where(o => o.productId == id).ToList();
        var product = context.Product.Find(id);

        var salesPerMonth = new double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        foreach(Order_Details sale in sales)
        {
            if (product != null)
            salesPerMonth[sale.day.Month] += product.productionCost * sale.orderQuantity;
        }
        var growthPerMonth = new string[12];
        var i = 0;
        foreach(float sale in salesPerMonth)
        {
            if(i != 12)
            growthPerMonth[i] = Functionality.calcGrowth(salesPerMonth[i], salesPerMonth[i + 1]).ToString();
            i++;
        }
        return growthPerMonth;
    }
}