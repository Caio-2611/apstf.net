using Microsoft.EntityFrameworkCore;
using APS_Final.Infrastructure.Data;
using APS_Final.Application.Mapping; 
using APS_Final.Domain.Repositories; 
using APS_Final.Infrastructure.Repositories; 
using APS_Final.Application.Interfaces; 
using APS_Final.Application.Services; 

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Mapster
MappingConfig.Configure(); 

// Add services to the container.

// 2. Registro do DbContext (Persistência) - AGORA USANDO SQLITE
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), // ⭐️ Alterado para UseSqlite
        sqlOptions =>
        {
            // Especifica que as Migrations estão no assembly da Infraestrutura
            sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
        })); // ⭐️ Removida a configuração específica do SQL Server

// 3. Registro dos Serviços e Repositórios (DI e IoC - Requisito 8)
// Repositórios (Infraestrutura)
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IModeloRepository, ModeloRepository>();

// Serviços de Aplicação (Application)
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IModeloService, ModeloService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Marca}/{action=Index}/{id?}");

app.Run();