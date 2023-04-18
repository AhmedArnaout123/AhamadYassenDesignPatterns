using DesignPatternsProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        "Server=DESKTOP-5Q7KTTD\\SQLEXPRESS;Database=DesignPatternsProject;Trusted_Connection=True;TrustServerCertificate=True;");
});

var client = new MongoClient("mongodb://localhost:27017");
var db = client.GetDatabase("DesignPatternsProject");

builder.Services.AddSingleton(db);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();