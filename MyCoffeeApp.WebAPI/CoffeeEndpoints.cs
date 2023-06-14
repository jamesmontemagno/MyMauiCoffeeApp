using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.WebAPI.Data;
namespace MyCoffeeApp.WebAPI;

public static class CoffeeEndpoints
{
    public static void MapCoffeeEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Coffee").WithTags(nameof(Coffee));

        group.MapGet("/", async (MyCoffeeAppWebAPIContext db) =>
        {
            return await db.Coffee.ToListAsync();
        })
        .WithName("GetAllCoffees")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Coffee>, NotFound>> (int id, MyCoffeeAppWebAPIContext db) =>
        {
            return await db.Coffee.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Coffee model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCoffeeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Coffee coffee, MyCoffeeAppWebAPIContext db) =>
        {
            var affected = await db.Coffee
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, coffee.Id)
                  .SetProperty(m => m.Roaster, coffee.Roaster)
                  .SetProperty(m => m.Name, coffee.Name)
                  .SetProperty(m => m.Image, coffee.Image)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCoffee")
        .WithOpenApi();

        group.MapPost("/", async (Coffee coffee, MyCoffeeAppWebAPIContext db) =>
        {
            db.Coffee.Add(coffee);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Coffee/{coffee.Id}",coffee);
        })
        .WithName("CreateCoffee")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, MyCoffeeAppWebAPIContext db) =>
        {
            var affected = await db.Coffee
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCoffee")
        .WithOpenApi();
    }
}
