using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Sakila.Domain.Abstractions;
using Sakila.Domain.Model;
using Sakila.Infrastructure;
using Sakila.Intrastructure;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomerRepository, DbCustomerRepository>();
builder.Services.AddScoped<IRentalRepository, DbRentalRepository>();

builder.Services.AddDbContext<SakilaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Sakila")));

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


// TODO: GET api/customers/{id}

app.MapGet("api/customers/{id}", async (int id, ICustomerRepository repository) =>
{
    var customer = await repository.GetAsync(id);

    if (customer is null)
        return Results.NotFound();

    return Results.Ok(customer);
});

app.MapGet("api/customers", async (ICustomerRepository repository) =>
{
    var customers = await repository.GetAllAsync();

    return Results.Ok(customers);
});

app.MapDelete("api/customers/{id}", async (int id, ICustomerRepository repository) =>
{
    await repository.RemoveAsync(id);

    return Results.Ok();
});

// TODO: GET api/rentals/{id}

app.MapGet("/api/rentals/{id}", async (IRentalRepository repository, int id) =>
{
    var rental = await repository.GetAsync(id);

    return Results.Ok(rental);
}).WithName("GetRentalById");

// TODO: POST api/rentals
app.MapPost("api/rentals", async (IRentalRepository repository, Rental rental) =>
{
    await repository.AddAsync(rental);

    return Results.CreatedAtRoute("GetRentalById", new { Id = rental.RentalId }, rental);
});


app.Run();
