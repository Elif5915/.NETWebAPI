
namespace Middleware.WepAPI.Middlewares;

public class LogMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        //loglama

        Log log = new(
            context.Request.HttpContext.Connection.RemoteIpAddress!.ToString(),
            context.Request.Method,
            context.Request.Path,
            context.Request.QueryString.Value ?? string.Empty,
            DateTime.Now);

        await next(context);
    }
}

//public class Log daha basit şekli var 
//{
//    public string IP { get; set; } = string.Empty;
    
//    public string MethodType { get; set; } = string.Empty;

//    public string EndPoint { get; set; } = string.Empty;

//    public string QueryString { get; set; } = string.Empty;

//    public DateTime Date { get; set; }

//}
public sealed record Log (
    string IP,
    string MethodType,
    string EndPoint,
    string QueryString,
    DateTime Date);