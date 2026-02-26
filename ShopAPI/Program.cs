using ApiBlazorWebassembly.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IShoppingRepository, ShoppingRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorOrigin", policy =>
    {
        // Replace with your Blazor app's origin (e.g. the URL where your Blazor app is running)
        policy.WithOrigins("https://localhost:7216")
              .AllowAnyHeader() // Allows headers like Content-Type  
              .AllowAnyMethod(); // Allows HTTP methods (GET, POST, etc.)  
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorOrigin");



app.UseAuthorization();

app.MapControllers();

app.Run();
