using System.ComponentModel.DataAnnotations; // permite usar las anotaciones de datos (Data Annotations)

namespace GestionExpedientes.Models // Define el espacio de nombres para la aplicación de gestión de expedientes
{
    public class Alumno
    {
        [Key] // Indica que AlumnoId es la llave primaria (PK)
        public int AlumnoId { get; set; } // Llave primaria

        [Required(ErrorMessage = "El nombre es obligatorio")] // Indica que el campo es obligatorio
        [StringLength(100)] // Limita la longitud máxima del nombre a 100 caracteres
        public string Nombre { get; set; } // Nombre del alumno

        [Required(ErrorMessage = "El apellido es obligatorio")] // Indica que el campo es obligatorio
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")] // Indica que el campo es obligatorio
        [DataType(DataType.Date)] // Especifica que el campo es de tipo fecha
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; } // Fecha de nacimiento del alumno

        [Required(ErrorMessage = "El grado es obligatorio")] // Indica que el campo es obligatorio
        [StringLength(50)]
        public string Grado { get; set; }

        // Relación con Expediente (un alumno tiene muchos expedientes)
        public ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>(); // Colección de expedientes asociados al alumno
    }
}
