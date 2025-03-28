var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS (optional, if you need cross-origin access)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

// Define API endpoint manually without `.WithOpenApi()`
app.MapGet("/movies", () =>
{
    return Results.Ok(new[]
    {
        new { name = "RRR", img = "https://upload.wikimedia.org/wikipedia/en/thumb/d/d7/RRR_Poster.jpg/220px-RRR_Poster.jpg", id = "6ca7" },
        new { name = "KGF", img = "https://m.media-amazon.com/images/M/MV5BM2M0YmIxNzItOWI4My00MmQzLWE0NGYtZTM3NjllNjIwZjc5XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", id = "392f" },
        new { name = "Shinchanupdate", img = "https://m.media-amazon.com/images/I/41AP1VGhL7L._AC_UF1000,1000_QL80_.jpg", id = "9762" }
    });
});

app.Run();
