using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.WepAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]

public sealed class InterfaceTestController1(ICache cache) : ControllerBase //(ıcache cache) => primary constructor denir. aşağıdaki kalıbın eşitidir. .net8 ile geldi.
//{
//    private readonly ICache _cache;
//    public InterfaceTestController1(ICache cache)  //artık bunu da bir değişkene bağlamamız gerekkki yakalayabilelim.
//    {
//      _cache = cache;
//    }


    [HttpGet]
    public IActionResult Get()
    //{
    //    RedisCache cache = new();
    //    cache.CreateRedisCache();
       cache.CreateCache();
        return Ok();
    }

    [HttpGet]
    public IActionResult Get2()
    {
    //RedisCache cache = new();
    //cache.CreateRedisCache();
    cache.CreateCache();
        return Ok();
    }
}
public interface ICache
{
    void CreateCache();
}

public class MemoryCache : ICache
{
    public MemoryCache() //constructor
    { 
    }
    public void CreateCache()
    {
    
    }
}

public class RedisCache : ICache
{
    public RedisCache() //constructor
    {

    }
    public void CreateCache()
    {

    }
}