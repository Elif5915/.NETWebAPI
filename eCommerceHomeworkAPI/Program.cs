using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

//rate limit haz�r
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", options =>
    {
        options.QueueLimit = 5; //kuyru�a 5 istek als�n
        options.PermitLimit = 10; // verdi�in sn ne ise onun i�inde 10 istek als�n
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; //
        options.Window = TimeSpan.FromSeconds(1); // her bir sn de 10 istek als�n 

    });
});

//cors politikas� 

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

// health check (health check u� k�t�phanesiz yap�m� bu �ekilde di�er ders de k�t�phaneleri kurup nas�l yap�ld���na bakt�k.)
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

app.UseRateLimiter(); // yukar�da tan�mlad���m�z fixed politam�z� kullanmas�n� s�yledik.

app.UseCors("cors1"); // cors politikam�z� kullanmas�n� s�yledik

app.UseAuthorization();

app.MapControllers().RequireRateLimiting("fixed"); // t�m endpoinletimizde/controller da  fixed isimli rate limit politikam�z� kullanal�m dedik.

app.MapHealthChecks("healthCheck");// health check mizi kullanmas�n� s�yledik ve �a��rd�k.

app.Run();
