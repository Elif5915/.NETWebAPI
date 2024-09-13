using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

//rate limit hazýr
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", options =>
    {
        options.QueueLimit = 5; //kuyruða 5 istek alsýn
        options.PermitLimit = 10; // verdiðin sn ne ise onun içinde 10 istek alsýn
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; //
        options.Window = TimeSpan.FromSeconds(1); // her bir sn de 10 istek alsýn 

    });
});

//cors politikasý 

builder.Services.AddCors(action =>
{
    action.AddPolicy("cors1", policy =>
    {
        policy
        .WithHeaders("https://www.tanersaydam.net")
        .WithHeaders("Authorization")
        .WithMethods("POST", "GET", "DELETE", "PUT");

    });

});

// health check (health check uý kütüphanesiz yapýmý bu þekilde diðer ders de kütüphaneleri kurup nasýl yapýldýðýna baktýk.)
builder.Services.AddHealthChecks().AddCheck("healthCheck", () => HealthCheckResult.Healthy());


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter(); // yukarýda tanýmladýðýmýz fixed politamýzý kullanmasýný söyledik.

app.UseCors("cors1"); // cors politikamýzý kullanmasýný söyledik

app.UseAuthorization();

app.MapControllers().RequireRateLimiting("fixed"); // tüm endpoinletimizde/controller da  fixed isimli rate limit politikamýzý kullanalým dedik.

app.MapHealthChecks("healthCheck");// health check mizi kullanmasýný söyledik ve çaðýrdýk.

app.Run();
