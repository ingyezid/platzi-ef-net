using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<ProjectefContext>(p => p.UseInMemoryDatabase("ProjectEF"));

builder.Services.AddSqlServer<ProjectefContext>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectEF;user id=admin;password=admin123");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] ProjectefContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
}); 

app.Run();
