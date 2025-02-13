using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Onix_Gym.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios
builder.Services.AddControllers(); // Para una API, no necesitamos AddControllersWithViews
builder.Services.AddDbContext<OnixGymDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuraci�n de autenticaci�n con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "OnixGymAuthCookie"; // Nombre de la cookie
        options.LoginPath = "/api/Account/Login"; // Ruta de inicio de sesi�n (para redireccionar si no est� autenticado)
        options.AccessDeniedPath = "/api/Account/AccessDenied"; // Ruta de acceso denegado
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Tiempo de expiraci�n de la cookie
        options.SlidingExpiration = true; // Renovar la cookie si el usuario est� activo
        options.Cookie.HttpOnly = true; // La cookie solo es accesible desde el servidor
        options.Cookie.SameSite = SameSiteMode.Strict; // Prevenir ataques CSRF
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Solo enviar la cookie sobre HTTPS
    });

// Configuraci�n de autorizaci�n
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); // Pol�tica para roles
});

// Configuraci�n de CORS (si tu frontend est� en un dominio diferente)
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

// Configuraci�n del pipeline de la aplicaci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Manejo de errores en producci�n
    app.UseHsts(); // HSTS (HTTP Strict Transport Security)
}

app.UseHttpsRedirection(); // Redirigir HTTP a HTTPS
app.UseStaticFiles(); // Servir archivos est�ticos (si es necesario)

app.UseRouting();

// Habilitar CORS
app.UseCors("AllowReactApp");

// Habilitar autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

app.Run();