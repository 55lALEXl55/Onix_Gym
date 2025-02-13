using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Onix_Gym.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers(); // Para una API, no necesitamos AddControllersWithViews
builder.Services.AddDbContext<OnixGymDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "OnixGymAuthCookie"; // Nombre de la cookie
        options.LoginPath = "/api/Account/Login"; // Ruta de inicio de sesión (para redireccionar si no está autenticado)
        options.AccessDeniedPath = "/api/Account/AccessDenied"; // Ruta de acceso denegado
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Tiempo de expiración de la cookie
        options.SlidingExpiration = true; // Renovar la cookie si el usuario está activo
        options.Cookie.HttpOnly = true; // La cookie solo es accesible desde el servidor
        options.Cookie.SameSite = SameSiteMode.Strict; // Prevenir ataques CSRF
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Solo enviar la cookie sobre HTTPS
    });

// Configuración de autorización
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); // Política para roles
});

// Configuración de CORS (si tu frontend está en un dominio diferente)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // URL de tu frontend (React)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // Permitir credenciales (cookies)
    });
});

var app = builder.Build();

// Configuración del pipeline de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Manejo de errores en producción
    app.UseHsts(); // HSTS (HTTP Strict Transport Security)
}

app.UseHttpsRedirection(); // Redirigir HTTP a HTTPS
app.UseStaticFiles(); // Servir archivos estáticos (si es necesario)

app.UseRouting();

// Habilitar CORS
app.UseCors("AllowReactApp");

// Habilitar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

app.Run();