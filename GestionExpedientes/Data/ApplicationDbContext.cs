using GestionExpedientes.Models;
using Microsoft.EntityFrameworkCore; // Importa el paquete Entity Framework Core para trabajar con bases de datos
namespace GestionExpedientes.Data // Define el espacio de nombres para la capa de datos de la aplicación
{
    public class ApplicationDbContext : DbContext // Clase que representa el contexto de la base de datos, hereda de DbContext
    {
        // Constructor: recibe las opciones de configuración
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet representa cada tabla en la base de datos
        public DbSet<Alumno> Alumnos { get; set; } // Tabla de Alumnos
        public DbSet<Materia> Materias { get; set; } // Tabla de Materias
        public DbSet<Expediente> Expedientes { get; set; } // Tabla de Expedientes

        // Configuración adicional de las relaciones
        protected override void OnModelCreating(ModelBuilder modelBuilder) // Método para configurar el modelo de datos
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la precisión del decimal para NotaFinal
            modelBuilder.Entity<Expediente>()
                .Property(e => e.NotaFinal)
                .HasColumnType("decimal(5,2)"); // 5 dígitos totales, 2 decimales (ejemplo: 10.00)

            // Configurar las relaciones
            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Alumno) // Un Expediente tiene UN Alumno
                .WithMany(a => a.Expedientes) // Un Alumno tiene MUCHOS Expedientes
                .HasForeignKey(e => e.AlumnoId) // Llave foránea en Expediente
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina un alumno, se eliminan sus expedientes

            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Materia) // Un Expediente tiene UNA Materia
                .WithMany(m => m.Expedientes) // Una Materia tiene MUCHOS Expedientes
                .HasForeignKey(e => e.MateriaId) // Llave foránea en Expediente
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina una materia, se eliminan sus expedientes
        }
    }
}
