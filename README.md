# Sistema de Gestión de Expedientes Académicos - Colegio San José

Sistema web desarrollado en **ASP.NET Core MVC** para la gestión integral de expedientes académicos, permitiendo el registro de alumnos, materias y calificaciones con análisis estadístico del rendimiento estudiantil.

## Características Principales

-  **Gestión de Alumnos**: CRUD completo con información personal y académica
-  **Gestión de Materias**: Administración del catálogo de asignaturas y docentes
-  **Gestión de Expedientes**: Registro de inscripciones y calificaciones con relaciones muchos a muchos
-  **Reportes Estadísticos**: Cálculo automático de promedios, rankings y métricas de rendimiento
-  **Gráficas Interactivas**: Visualización de datos con Chart.js (barras, dona, líneas)
-  **Interfaz Responsive**: Diseño adaptable con Bootstrap 5
-  **Validaciones**: Validación de datos en cliente y servidor
-  **Integridad Referencial**: Eliminación en cascada configurada

##  Tecnologías Utilizadas

- **Framework**: ASP.NET Core MVC (.NET 9.0)
- **ORM**: Entity Framework Core 9.0.10
- **Base de Datos**: SQL Server / SQL Server LocalDB
- **Frontend**: HTML5, CSS3, Bootstrap 5.3, Chart.js 4.4
- **Lenguaje**: C# 
- **Patrón**: MVC (Model-View-Controller)

##  Requisitos Previos

Antes de instalar el proyecto, es necesario tener:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) o superior
- [SQL Server 2019+](https://www.microsoft.com/sql-server/sql-server-downloads) o SQL Server LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (Recomendado) o Visual Studio Code
- [Git](https://git-scm.com/) para clonar el repositorio

##  Instalación y Configuración

### 1. Clonar el repositorio
```bash
git clone https://github.com/Lyoko97/GestionExpedientes
cd GestionExpedientes
```

### 2. Restaurar paquetes NuGet

**Desde la terminal:**
```bash
dotnet restore
```

**O desde Visual Studio:**
- Click derecho en el proyecto → Restore NuGet Packages

### 3. Configurar la cadena de conexión

Abrir el archivo `appsettings.json` y verificar/modificar la cadena de conexión según su entorno:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GestionExpedientesDB;Trusted_Connection=true;MultipleActiveResultSets=true"
}
```

**Opciones de configuración:**

- **LocalDB (por defecto):** `Server=(localdb)\\mssqllocaldb;...`
- **SQL Server local:** `Server=localhost;Database=GestionExpedientesDB;Trusted_Connection=true;...`
- **SQL Server con autenticación:** `Server=localhost;Database=GestionExpedientesDB;User Id=tu_usuario;Password=tu_contraseña;...`

### 4. Crear la base de datos con migraciones

El proyecto utiliza **Entity Framework Core Migrations** para gestionar la base de datos.

**Opción A - Desde la terminal:**
```bash
dotnet ef database update
```

**Opción B - Desde Visual Studio:**
1. Ir a: **Tools → NuGet Package Manager → Package Manager Console**
2. Ejecutar el comando:
```powershell
   Update-Database
```

Este comando creará automáticamente:
- La base de datos `GestionExpedientesDB`
- Las tablas: `Alumnos`, `Materias`, `Expedientes`
- Las relaciones y restricciones configuradas

### 5. Ejecutar la aplicación

**Desde la terminal:**
```bash
dotnet run
```

**Desde Visual Studio:**
- Presionar **F5** o click en el botón de Start

La aplicación estará disponible en:
- HTTPS: `https://localhost:7xxx`
- HTTP: `http://localhost:5xxx`

*(Los puertos exactos se mostrarán en la consola al ejecutar)*

### 6. Agregar datos de prueba

La base de datos se crea vacía. Para utilizar todas las funcionalidades del sistema:

1. **Agregar Alumnos:**
   - Ir a **Alumnos** → **Create New**
   - Completar: Nombre, Apellido, Fecha de Nacimiento, Grado

2. **Agregar Materias:**
   - Ir a **Materias** → **Create New**
   - Completar: Nombre de la Materia, Docente

3. **Agregar Expedientes:**
   - Ir a **Expedientes** → **Create New**
   - Seleccionar Alumno y Materia
   - Ingresar Nota Final (0-10) y Observaciones

4. **Ver Estadísticas:**
   - Ir a **Promedios** para ver gráficas y análisis

## Estructura de la Base de Datos

El sistema implementa una relación **muchos a muchos** entre Alumnos y Materias mediante la tabla intermedia Expedientes:
```
┌─────────────────────┐         ┌──────────────────────┐         ┌─────────────────────┐
│      Alumno         │         │     Expediente       │         │       Materia       │
├─────────────────────┤         ├──────────────────────┤         ├─────────────────────┤
│ AlumnoId (PK)       │◄────────│ ExpedienteId (PK)    │────────►│ MateriaId (PK)      │
│ Nombre              │         │ AlumnoId (FK)        │         │ NombreMateria       │
│ Apellido            │         │ MateriaId (FK)       │         │ Docente             │
│ FechaNacimiento     │         │ NotaFinal            │         └─────────────────────┘
│ Grado               │         │ Observaciones        │
└─────────────────────┘         └──────────────────────┘
```

### Relaciones:
- **Alumno → Expediente**: Uno a Muchos (un alumno tiene varios expedientes)
- **Materia → Expediente**: Uno a Muchos (una materia tiene varios expedientes)
- **Eliminación en Cascada**: Al eliminar un alumno o materia, se eliminan sus expedientes asociados

## Estructura del Proyecto
```
GestionExpedientes/
├── Controllers/          # Controladores MVC
│   ├── AlumnosController.cs
│   ├── MateriasController.cs
│   ├── ExpedientesController.cs
│   └── HomeController.cs
├── Data/                # Contexto de base de datos
│   └── ApplicationDbContext.cs
├── Models/              # Modelos de datos
│   ├── Alumno.cs
│   ├── Materia.cs
│   └── Expediente.cs
├── Views/               # Vistas Razor
│   ├── Alumnos/
│   ├── Materias/
│   ├── Expedientes/
│   ├── Home/
│   └── Shared/
├── Migrations/          # Migraciones de EF Core
├── wwwroot/            # Archivos estáticos (CSS, JS, imágenes)
├── appsettings.json    # Configuración (cadena de conexión)
└── Program.cs          # Punto de entrada de la aplicación
```

##  Funcionalidades Destacadas

### 1. Vista de Detalles de Alumno
- Información personal completa
- Estadísticas individuales (promedio, materias cursadas, nota máxima)
- Lista de todas las materias inscritas con calificaciones
- Acceso directo para editar expedientes

### 2. Reportes y Estadísticas
- Ranking de alumnos por promedio
- Distribución de rendimiento académico
- Gráficas interactivas:
  - Barras: Promedio por alumno
  - Dona: Distribución de categorías (Excelente, Bueno, Regular, Necesita Mejorar)
  - Líneas: Comparativa de notas máximas, promedios y mínimas

### 3. Validaciones Implementadas
- Campos obligatorios en todos los formularios
- Rango de notas: 0 a 10
- Formato de fecha válido
- Longitud máxima de campos de texto

##  Soluciones a problemas que se encontraron durante el desarrollo:

### Error: "Cannot implicitly convert type 'decimal' to 'int'"
**Solución:** Asegurarse de que las propiedades de navegación en los modelos estén marcadas como opcionales (`?`).

### Error: "The Expedientes field is required"
**Solución:** Inicializa las colecciones de navegación:
```csharp
public ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
```

### Error de conexión a la base de datos
**Solución:** 
1. Verificar que SQL Server/LocalDB esté en ejecución
2. Revisar la cadena de conexión en `appsettings.json`
3. Para LocalDB, ejecutar: `sqllocaldb start mssqllocaldb`

### Las migraciones no se aplican
**Solución:**
```bash
dotnet ef database drop     # Elimina la BD
dotnet ef database update   # Recrea desde cero
```

## Licencia

Este proyecto fue desarrollado con fines académicos para el curso de Desarrollo de Aplicaciones con Software Propietario en la Universidad Don Bosco.
