using System.Data;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

// base de datos en memoria
// builder.Services.AddDbContext<ProjectefContext>(p=> p.UseInMemoryDatabase("ProjectEF"));

// base de datos relacional y en sql server
builder.Services.AddSqlServer<ProjectefContext>(builder.Configuration.GetConnectionString("conexionProjectEF"));

var app = builder.Build();

// Para que se actualice la base de datos tan pronto se lanza o dice run sin abrir el navegador
using (var context = new ProjectefContext(app.Configuration))
{
    context.Database.Migrate();
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] ProjectefContext dbContext) =>
{
    bool dbCreated = dbContext.Database.EnsureCreated();
    
    string result0 = "Base de datos recien creada: " + dbCreated;
    string result1 = "Base de datos en memoria: " + dbContext.Database.IsInMemory();
    string result2 = "Base de datos relacional: " + dbContext.Database.IsRelational();
    string result3 = "Base de datos sql server: " + dbContext.Database.IsSqlServer();
    string sumaResultado = " <p> " + result0 + " <br/> " + result1 + " <br/> " + result2 + " <br/> " + result3 + "</p>";

    return Results.Ok(sumaResultado);
});

app.MapGet("/api/tareas", async ([FromServices] ProjectefContext dbContext) =>
{
    return Results.Ok(
        dbContext.Tareas.Include(p=>p.Categoria).Where(p=>p.PrioridadTarea == Prioridad.Alta)    
    );

});

app.MapGet("/api/categorias", async ([FromServices] ProjectefContext dbContext) =>
{
    return Results.Ok(dbContext.Categorias);

});


app.MapPost("/api/tareas", async ([FromServices] ProjectefContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    // await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();

});

app.Run();


