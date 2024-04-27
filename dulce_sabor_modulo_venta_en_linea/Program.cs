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
builder.Services.AddTransient<IUserStore<Cliente>, ClienteStore>();
builder.Services.AddIdentityCore<Cliente>();

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
