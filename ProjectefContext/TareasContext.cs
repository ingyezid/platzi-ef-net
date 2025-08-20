using Microsoft.EntityFrameworkCore;

namespace projectef.Models;

public class ProjectefContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public ProjectefContext(DbContextOptions<ProjectefContext> options) : base(options)  { }

 }
