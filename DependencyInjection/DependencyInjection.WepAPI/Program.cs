using DependencyInjection.WepAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<Product>();
builder.Services.AddScoped<Test>();

// scoped,transient,singleton olmak üzere üç tane yaþam süremiz var.

builder.Services.AddScoped<ICache,MemoryCache>(); //ýcache ýnterface çaðýrýldýðý zaman memorycache dönüþsün. bu interface belirtitðimiz classa dönüþebilmesi için memory classýmýzýn mutlaka implement etmesi gerek ýcache. 

//builder.Services.AddTransient<Product>(); //=> Dependency Injection
//builder.Services.AddSingleton<Product>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//buradan yukarýsý service register kýsmýmýz; burada service register yapabiliyoruz,dependency ýnjeciton yapabiliyoruz.
//buradan aþaðýsý ise middleware kýsmýmýz  

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
