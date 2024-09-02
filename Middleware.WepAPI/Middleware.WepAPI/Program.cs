using Middleware.WepAPI.Middlewares;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<LogMiddleware>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<LogMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception ex)
    {
        var response = new {Message = ex.Message};
        var responseString = JsonSerializer.Serialize(response);

        context.Response.StatusCode = 500;
        if(ex.GetType() == typeof(DivideByZeroException))
        {
            context.Response.StatusCode = 409;
        }

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(responseString);
        
    }
});

app.Run();
