using eCommerceHomeworkAPI.Models;
using eCommerceHomeworkAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceHomeworkAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ShoppingCartsController : ControllerBase
{
    private static List<ShoppingCart> Carts = new();

    [HttpGet]
    public IActionResult Add(Guid productId)
    {
        Product? product = ProductsController.Products.Find(p => p.Id == productId); //ürünlere eriştik 
        if (product is null)
        {
            return BadRequest(Result.Failed("Product not Found!"));
        }
        ShoppingCart shoppingCart = new()
        {
            ProductName = product.Name,
            ProductPrice = product.Price,
        };

        Carts.Add(shoppingCart); //ürün sepete ekleme işi ok.
        return Ok(Result.Succeed("Product has been successful added to shopping cart.."));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Carts);
    }


    [HttpGet("{cartQwner}")] //route params
    public IActionResult Pay(string cartQwner)
    {
        List<Order> orders = Carts.Select(s => new Order() //carttaki ürünleri select ile alıp orders dönüştürüp ekleyebildik.
        {
            ProductName = s.ProductName,
            ProductPrice = s.ProductPrice,
        }).ToList();


        OrderController.orders.AddRange(orders); // addrange ile toplu liste ekleyebiliriz.

        // 1.yol bu 
        //foreach (var cart in Carts) 
        //{
        //    Order order = new()
        //    {
        //        ProductName = cart.ProductName,
        //        ProductPrice = cart.ProductPrice,
        //    };
        //    OrderController.orders.Add(order);
        //}

        Carts.RemoveRange(0, Carts.Count); //artık sepetteki her şey siparişe gittiği için sepet içini tamaamen boşaltıyoruz.

        return Ok(Result.Succeed("Payment is successful."));
    }

}