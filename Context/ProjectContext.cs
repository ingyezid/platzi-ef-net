using Microsoft.EntityFrameworkCore;

namespace projectef.Models;

public class ProjectefContext : DbContext
{
    protected readonly IConfiguration _config;

    public ProjectefContext(IConfiguration configuration)
    {
        _config = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("conexionProjectEF"));
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria()
        {
            CategoriaId = Guid.Parse("3b8b7607-3ef4-4820-8e68-dacc4ea2d93a"),
            Nombre = "Actividades Pendientes",
            Peso = 20            
        });
        categoriasInit.Add(new Categoria()
        {
            CategoriaId = Guid.Parse("3b8b7607-3ef4-4820-8e68-dacc4ea2d902"),
            Nombre = "Actividades Personales",
            Peso = 50
            
        });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit);
        });


        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea()
        {
            TareaId = Guid.Parse("3b8b7607-3ef4-4820-8e68-dacc4ea2d910"),
            CategoriaId = Guid.Parse("3b8b7607-3ef4-4820-8e68-dacc4ea2d93a"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "Pago de Servicios Publicos",
            FechaCreacion = DateTime.Now
        });
        tareasInit.Add(new Tarea()
        {
            TareaId = Guid.Parse("3b8b7607-3ef4-4820-8e68-dacc4ea2d920"),
            CategoriaId = Guid.Parse("3b8b7607-3ef4-4820-8e68-dacc4ea2d902"),
            PrioridadTarea = Prioridad.Baja,
            Titulo = "Terminar de ver pelicula en Netflix",
            FechaCreacion = DateTime.Now
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
            tarea.Property(p => p.Puntos);
            tarea.Property(p => p.FechaLimite);
            
            tarea.HasData(tareasInit);
        });
    }
    
}
