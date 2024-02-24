using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/users", (BangazonDbContext db) =>
{
    return db.Users.ToList();
});


app.MapGet("/api/users/{id}", (BangazonDbContext db, int id) =>
{
    var userID = db.Users.FirstOrDefault(c => c.ID == id);

    if (userID == null)
    {
        return Results.NotFound("User Not Found.");
    }

    return Results.Ok(userID);
});


app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Products.ToList();
});


app.MapGet("/api/products/{id}", (BangazonDbContext db, int id) =>
{
    var productID = db.Products.FirstOrDefault(c => c.ID == id);

    if (productID == null)
    {
        return Results.NotFound("Product Not Found.");
    }

    return Results.Ok(productID);
});


app.MapGet("/api/orders", (BangazonDbContext db) =>
{
    return db.Orders.ToList();
});


app.MapGet("/api/orders/{id}", (BangazonDbContext db, int id) =>
{
    var orderID = db.Orders.FirstOrDefault(c => c.ID == id);

    if (orderID == null)
    {
        return Results.NotFound("Order Not Found.");
    }

    return Results.Ok(orderID);
});

app.MapGet("/api/categories", (BangazonDbContext db) =>
{
    return db.Categories.ToList();
});

app.Run();

