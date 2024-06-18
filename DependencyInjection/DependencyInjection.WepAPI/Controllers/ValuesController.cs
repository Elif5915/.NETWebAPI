using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.WepAPI.Controllers;
[Route("api/[controller]/[Action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly Product _product;
    private readonly Test _test;

    public ValuesController(Product product, Test test) // product values constructorına inject etmiş oluyoruz. ıoc container dediğimiz program.cs gidiyor ve bana product classını ver diyoruz.
    {
        _product = product;
        _test = test;
    }

    [HttpGet]
    public IActionResult Get1()
    {
        //Product product = new();
        //var result = _product.Name;
        _test.Method();
        return Ok();
    }

    //[HttpGet]
    //public IActionResult Get2()
    //{
    //    var result = _product.Name;
    //    return Ok();
    //}
}

public class Product
{
    public Product()
    {

    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class Test
{
    public Test(Product product)
    {
        product.Name = "Elif Yildirim";

    }

    public void Method()
    {

    }
}