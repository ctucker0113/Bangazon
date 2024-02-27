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


//GET All Users
app.MapGet("/api/users", (BangazonDbContext db) =>
{
    return db.Users.ToList();
});


// GET a Single User
app.MapGet("/api/users/{id}", (BangazonDbContext db, int id) =>
{
    var userID = db.Users.FirstOrDefault(c => c.ID == id);

    if (userID == null)
    {
        return Results.NotFound("User Not Found.");
    }

    return Results.Ok(userID);
});


// GET All Products
app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Products.ToList();
});


// GET A Single Product
app.MapGet("/api/products/{id}", (BangazonDbContext db, int id) =>
{
    var productID = db.Products.FirstOrDefault(c => c.ID == id);

    if (productID == null)
    {
        return Results.NotFound("Product Not Found.");
    }

    return Results.Ok(productID);
});



//GET All Orders
app.MapGet("/api/orders", (BangazonDbContext db) =>
{
    return db.Orders.ToList();
});


//GET a Single Order
app.MapGet("/api/orders/{id}", (BangazonDbContext db, int id) =>
{
    var orderID = db.Orders.FirstOrDefault(c => c.ID == id);

    if (orderID == null)
    {
        return Results.NotFound("Order Not Found.");
    }

    return Results.Ok(orderID);
});

//GET All Categories
app.MapGet("/api/categories", (BangazonDbContext db) =>
{
    return db.Categories.ToList();
});


// GET All Products for a Single Seller
app.MapGet("/api/products/by-seller", (BangazonDbContext db, int sellerId) =>
{
    var productsFilteredBySeller = db.Products.Where(c => c.SellerID == sellerId).ToList();

    // If any of the products do NOT match...
    if (!productsFilteredBySeller.Any())
    {
        return Results.NotFound("No Products found for this seller.");
    }

    return Results.Ok(productsFilteredBySeller);
});

// GET All Products for a Single Category
app.MapGet("/api/products/by-category", (BangazonDbContext db, int categoryId) =>
{
    var productsFilteredByCategory = db.Products.Where(c => c.CategoryID == categoryId).ToList();

    // If any of the products do NOT match...
    if (!productsFilteredByCategory.Any())
    {
        return Results.NotFound("No Products found for this category.");
    }

    return Results.Ok(productsFilteredByCategory);
});

// GET All Purchases For a Single User
app.MapGet("/api/orders/by-user", (BangazonDbContext db, int userId) =>
{
    var allOrdersForASingleUser = db.Orders.Where(c => c.CustomerID == userId).ToList();

    if (!allOrdersForASingleUser.Any())
    {
        return Results.NotFound("No Orders found for this customer.");
    }

    return Results.Ok(allOrdersForASingleUser);
});


// CREATE a User
app.MapPost("/api/users", (BangazonDbContext db, User newUser) =>
{
    db.Users.Add(newUser);
    db.SaveChanges();
    return Results.Created($"/api/users/{newUser.ID}", newUser);
});


app.Run();

