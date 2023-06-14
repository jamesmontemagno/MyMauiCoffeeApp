using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyCoffeeApp.WebAPI.Data;
using MyCoffeeApp.WebAPI;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MyCoffeeAppWebAPIContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MyCoffeeAppWebAPIContext") ?? throw new InvalidOperationException("Connection string 'MyCoffeeAppWebAPIContext' not found.")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCoffeeEndpoints();


app.Run();
