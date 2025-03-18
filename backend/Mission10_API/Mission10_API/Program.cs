// Payton Hatch
// Group 4-6
// Program class 

using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Mission10_API.Models; // Adjust namespace

var builder = WebApplication.CreateBuilder(args);

// add cors for connection
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();

// define db
builder.Services.AddDbContext<BowlingDbContext>(options =>
    options.UseSqlite("Data Source=BowlingLeague.sqlite"));

var app = builder.Build();

app.UseCors("AllowAll"); // Enable CORS

app.MapControllers();
app.Run();


