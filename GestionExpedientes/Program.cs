using Microsoft.EntityFrameworkCore; // Importa el paquete Entity Framework Core para trabajar con bases de datos
using GestionExpedientes.Data; // Importa el espacio de nombres donde se encuentra ApplicationDbContext

var builder = WebApplication.CreateBuilder(args); // Crea el constructor de la aplicación web

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar Entity Framework con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options => // Agrega el contexto de la base de datos al contenedor de servicios
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configura la cadena de conexión a SQL Server desde appsettings.json

var app = builder.Build(); // Construye la aplicación web

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
