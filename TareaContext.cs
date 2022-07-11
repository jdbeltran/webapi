using Microsoft.EntityFrameworkCore;
using webapi.Models;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Tarea> Tareas {get; set;}

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria{ CategoriaId = Guid.Parse("fe3de506-c38e-4c90-ac52-da0540dfdfb4ef"), Nombre ="Actividades Pendientes" ,Peso = 20}); 
        categoriasInit.Add(new Categoria{ CategoriaId = Guid.Parse("fe3de506-c38e-4c90-ac52-da0540dfdfb402"), Nombre ="Actividades Personales", Peso = 50});

        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p=>p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() {TareaId =  Guid.Parse("fe3de506-c38e-4c90-ac52-da0540dfdfb410"),CategoriaId = Guid.Parse("fe3de506-c38e-4c90-ac52-da0540dfdfb4ef"), PrioridadTarea = Prioridad.Media, Titulo ="Pago dde servicios publicos", FechaCreacion = DateTime.Now});   
        tareasInit.Add(new Tarea() {TareaId =  Guid.Parse("fe3de506-c38e-4c90-ac52-da0540dfdfb411"),CategoriaId = Guid.Parse("fe3de506-c38e-4c90-ac52-da0540dfdfb402"), PrioridadTarea = Prioridad.Baja, Titulo ="Terminar de ver pelicula en netflix", FechaCreacion = DateTime.Now});
    
          modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=>p.CategoriaId);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=>p.PrioridadTarea);
            tarea.Property(p=>p.FechaCreacion);
            tarea.Ignore(p=>p.Resumen); 
            tarea.HasData(tareasInit);
        });
    } 
}