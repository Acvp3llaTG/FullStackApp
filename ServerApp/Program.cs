var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(cors =>
{
    cors.AddPolicy("cors-policy",
        builder => builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});

var app = builder.Build();




app.UseCors("cors-policy");



app.MapGet("/api/productlist", () =>
{
    var products = new[]
    {
        new
        {
            id = 1,
            name = "Laptop",
            price = 1200.50,
            stock = 25,
            category = new
            {
                id = 101,
                name = "Electronics"
            }
        },
        new
        {
            id = 2,
            name = "Headphones",
            price = 50.00,
            stock = 100,
            category = new
            {
                id = 102,
                name = "Accessories"
            }
        }
    };

    return Results.Json(products, new System.Text.Json.JsonSerializerOptions
    {
        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
        WriteIndented = true
    });
});

app.Run();