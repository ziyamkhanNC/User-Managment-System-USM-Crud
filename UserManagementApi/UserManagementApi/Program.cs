using Microsoft.EntityFrameworkCore;
using UserMangementApi.Data;

var builder = WebApplication.CreatBuilder(args);

// Now we will Register an Services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Enable OpenApi (Swagger)
builder.Services.AddOpenApi();

var app = builder.Build();

// now lets configure the HTTP Request Pipeline 
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.run();
