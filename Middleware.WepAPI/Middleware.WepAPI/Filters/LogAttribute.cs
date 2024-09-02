using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware.WepAPI.Filters;

public sealed class LogAttribute : Attribute, IActionFilter  //önce class yazılır sonra interface yazılır
{
    public void OnActionExecuted(ActionExecutedContext context) //uygulamanın başına girer,
    {
        // method tamamlandıktan sonra 
     
    }

    public void OnActionExecuting(ActionExecutingContext context) //uygulamanın sonuna girer,
    {
        //method çalışmadan önce
       
    }
}

//public sealed class LogAttribute : ActionFilterAttribute //bu base practies açısından tercih edilmez ama doğrudur yazılımcını üstteki base practiesdır
//{
//    public override void OnActionExecuting(ActionExecutingContext context)
//    {
//        // method başlamadan önce 
//        base.OnActionExecuting(context);
//    }

//    public override void OnActionExecuted(ActionExecutedContext context)
//    {
//        //method bittikten sonra 
//        base.OnActionExecuted(context);
//    }
//}
