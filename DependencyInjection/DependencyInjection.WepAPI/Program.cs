using DependencyInjection.WepAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<Product>();
builder.Services.AddScoped<Test>();

// scoped,transient,singleton olmak �zere �� tane ya�am s�remiz var.

builder.Services.AddScoped<ICache,MemoryCache>(); //�cache �nterface �a��r�ld��� zaman memorycache d�n��s�n. bu interface belirtit�imiz classa d�n��ebilmesi i�in memory class�m�z�n mutlaka implement etmesi gerek �cache. 

//builder.Services.AddTransient<Product>(); //=> Dependency Injection
//builder.Services.AddSingleton<Product>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//buradan yukar�s� service register k�sm�m�z; burada service register yapabiliyoruz,dependency �njeciton yapabiliyoruz.
//buradan a�a��s� ise middleware k�sm�m�z  

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
