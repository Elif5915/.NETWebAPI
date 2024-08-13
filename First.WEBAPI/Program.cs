using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// cors politikas�

builder.Services.AddCors(action =>
{
    action.AddPolicy("First", policy =>
    {
        policy
        .WithOrigins("https://www.tanersaydam.net", "http://127.0.0.1:5500") // web sitelerine izin verir.
        .WithMethods("GET")
        .WithHeaders("SecretKey");
    });

    action.AddPolicy("Second", policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });

    action.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://www.tanersaydam.net"); //web sitelerine izin verir.
    });
});

//rate limiting ayarlamas� 

builder.Services.AddRateLimiter(configure =>
{
    configure.AddFixedWindowLimiter("Fixed", options =>
    {
        //base practices de�erleri a�a��daki gibidir.

        options.PermitLimit = 100; //kabul edilecek istek say�s�
        options.Window = TimeSpan.FromSeconds(10); //ka� saniyede bir istek als�n
        options.QueueLimit = 100; //kuyru�a alma
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });

    configure.AddSlidingWindowLimiter("sliding", options =>
    {
        options.PermitLimit = 100; //kabul edilecek istek say�s�
        options.Window = TimeSpan.FromSeconds(10); //ka� saniyede bir istek als�n
        options.QueueLimit = 100; //kuyru�a alma
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.SegmentsPerWindow = 100;

    });
});

//health checks 

builder.Services.AddHealthChecks();
builder.Services.AddHealthChecksUI(options =>
{
    options.AddHealthCheckEndpoint("HealthCheck API", "/check");
}).AddInMemoryStorage();


builder.Services.AddHttpContextAccessor();
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

app.UseHealthChecks("/check", new HealthCheckOptions
{

    ResultStatusCodes =
    {
        [HealthStatus.Healthy]= StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy]= StatusCodes.Status503ServiceUnavailable
    }
});

app.UseRateLimiter();

app.UseCors("First"); 

app.UseStaticFiles(); // bu miidleware bizim wwwroot i�erisine att���m�z dosyalar�n�n browser �zerinden/d��ar�dan eri�imimizi a�ar.

app.UseAuthorization(); 

app.MapControllers().RequireRateLimiting("Fixed"); // t�m endpointlerde rate limiti uygula dedik.

app.MapGet("/test",() => //minimal api ile canl�daki ap� �al���� �al��mad���n�kontrol edebilriz.
{
    return new { Message = "API is working..." };
});

app.MapHealthChecksUI(options => options.UIPath = "/dashboard");
app.Run();
