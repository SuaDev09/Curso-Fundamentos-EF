using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria(){ 
            CategoriaId = Guid.Parse("1288fce7-4764-4637-b6f2-9616ebcbe89a"),
            Nombre = "Actividades pendientes",
            Peso = 20,
            });
        categoriasInit.Add(new Categoria(){ 
            CategoriaId = Guid.Parse("1288fce7-4764-4637-b6f2-9616ebcbe802"),
            Nombre = "Actividades Personales",
            Peso = 50,
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
        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("1288fce7-4764-4637-b6f2-9616ebcbe810"),
            CategoriaId = Guid.Parse("1288fce7-4764-4637-b6f2-9616ebcbe89a"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "Pago de servicios publicos",
            FechaCreacion = DateTime.Now,
        });

        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("1288fce7-4764-4637-b6f2-9616ebcbe811"),
            CategoriaId = Guid.Parse("1288fce7-4764-4637-b6f2-9616ebcbe802"),
            PrioridadTarea = Prioridad.Alta,
            Titulo = "Terminar curso de platzi",
            FechaCreacion = DateTime.Now,
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

            tarea.HasData(tareasInit);
        });
    }

}