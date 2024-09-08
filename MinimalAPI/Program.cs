using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/GetAllUsers", async (IUserService userService, string age, string name) =>
{
    await userService.CreateUserAsync();
    await Task.CompletedTask;
    return "API is working...";
});

app.Run();
