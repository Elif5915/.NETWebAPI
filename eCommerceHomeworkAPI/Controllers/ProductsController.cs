using eCommerceHomeworkAPI.Dtos;
using eCommerceHomeworkAPI.Models;
using eCommerceHomeworkAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceHomeworkAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ProductsController : ControllerBase
{
    public static List<Product> Products = new(); //static bir ürün listesi oluşturduk. statik olmasının sebebi uyg.yeniden çalışsa bie değerlerim değişmesin sabit kalsın.


    [HttpPost]

    public IActionResult Create(CreateProductDto request)
    {
        bool isNameExists = Products.Any(p => p.Name == request.Name);
        if (isNameExists)
        {
            return BadRequest(Result.Failed("This product name is already exists..."));
        }
        if (request.Price <= 0)
        {
            return BadRequest(Result.Failed("Product price must be greater then 0"));
        }

        Product product = new Product()
        {
            Name = request.Name,
            Price = request.Price,
        };

        Products.Add(product);
        return Ok(Result.Succeed("Product create is successful.."));

    }


    [HttpGet]
    public IActionResult GetAll()
    {
        //db olsaydı; db ye bağlan ve verileri çek işlemi yapacaktık.
        return Ok(Products.OrderBy(p => p.Name));
    }

    [HttpDelete]
    public IActionResult DeleteById(Guid id)
    {
        Product? product = Products.Find(p => p.Id == id);
        if (product is null)
        {
            return BadRequest(Result.Failed("Product not found.."));
        }

        Products.Remove(product);
        return Ok(Result.Succeed("Product delete is successful"));
    }

    [HttpPut]
    public IActionResult Update(UpdateProductDto request)
    {
        //önce ürünümü bul
        Product? product = Products.Find(p => p.Id == request.Id);
        if (product is null)
        {
            return BadRequest(Result.Failed("Product not found.."));
        }

        if (product.Name != request.Name)
        {
            bool isNameExists = Products.Any(p => p.Name == request.Name);
            if (isNameExists)
            {
                return BadRequest(Result.Failed("This product name is already exists..."));
            }

        }

        product.Name = request.Name;
        product.Price = request.Price;

        return Ok(Result.Succeed("Product update is succesfull:)"));
    }
}
