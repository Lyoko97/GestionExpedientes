using System.ComponentModel.DataAnnotations; // permite usar las anotaciones de datos (Data Annotations)
using System.ComponentModel.DataAnnotations.Schema; // using es específico para configurar el esquema de la base de datos

namespace GestionExpedientes.Models // Define el espacio de nombres para la aplicación de gestión de expedientes
{
    public class Expediente // Clase que representa un expediente académico
    {
        [Key] // Indica que ExpedienteId es la llave primaria (PK)
        public int ExpedienteId { get; set; } // Llave primaria

        // Llave foránea hacia Alumno
        [Required]
        [Display(Name = "Alumno")]
        public int AlumnoId { get; set; }

        // Llave foránea hacia Materia
        [Required]
        [Display(Name = "Materia")]
        public int MateriaId { get; set; }

        [Required(ErrorMessage = "La nota final es obligatoria")] // Indica que el campo es obligatorio
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10")] // Valida que la nota esté en el rango de 0 a 10
        [Display(Name = "Nota Final")] // Etiqueta para mostrar en vistas
        public decimal NotaFinal { get; set; } // Nota final del expediente

        [StringLength(500)]
        public string? Observaciones { get; set; } // Observaciones adicionales (opcional)

        // Propiedades de navegación
        // Propiedades de navegación
        [ForeignKey("AlumnoId")]
        public Alumno? Alumno { get; set; }

        [ForeignKey("MateriaId")]
        public Materia? Materia { get; set; }
    }
}
