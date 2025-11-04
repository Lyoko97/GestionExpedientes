using System.ComponentModel.DataAnnotations; // permite usar las anotaciones de datos (Data Annotations)

namespace GestionExpedientes.Models // Define el espacio de nombres para la aplicación de gestión de expedientes
{
    public class Materia
    {
        [Key] // Indica que MateriaId es la llave primaria (PK)
        public int MateriaId { get; set; } // Llave primaria

        [Required(ErrorMessage = "El nombre de la materia es obligatorio")] // Indica que el campo es obligatorio
        [StringLength(100)]
        [Display(Name = "Nombre de la Materia")] // Etiqueta para mostrar en vistas
        public string NombreMateria { get; set; } // Nombre de la materia

        [Required(ErrorMessage = "El nombre del docente es obligatorio")] // Indica que el campo es obligatorio
        [StringLength(100)]
        public string Docente { get; set; } // Nombre del docente

        // Relación con Expediente (una materia tiene muchos expedientes)
        public ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>(); // Colección de expedientes asociados a la materia
    }
}
