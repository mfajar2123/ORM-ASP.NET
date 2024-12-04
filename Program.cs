using Microsoft.EntityFrameworkCore;
using UserCommentsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Konfigurasi DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33))
    ));

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
