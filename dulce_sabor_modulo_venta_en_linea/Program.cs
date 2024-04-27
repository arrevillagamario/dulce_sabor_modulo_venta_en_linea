using dulce_sabor_modulo_venta_en_linea.Models;
using dulce_sabor_modulo_venta_en_linea.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DulceSaborContext>(options =>
options.UseSqlServer("name=DefaultConnection"));
builder.Services.AddTransient<IRepositorioClientes, RepositorioClientes>();
builder.Services.AddTransient<IServicioGeneral, ServicioGeneral>();
builder.Services.AddTransient<IUserStore<Cliente>, ClienteStore>();
builder.Services.AddTransient<SignInManager<Cliente>>();
builder.Services.AddTransient<IAutenticacionCliente, AutenticacionCliente>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
}).AddCookie(IdentityConstants.ApplicationScheme, opciones =>
{
    opciones.LoginPath = "/cliente/login";
});

builder.Services.AddIdentityCore<Cliente>(opciones =>
{
    opciones.Password.RequireDigit = true;
    opciones.Password.RequireLowercase = true;
    opciones.Password.RequireUppercase = true;
    opciones.Password.RequireNonAlphanumeric = true;

}).AddErrorDescriber<MensajesErrorIdentity>();

var app = builder.Build();

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
