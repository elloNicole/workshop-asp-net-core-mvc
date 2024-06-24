using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using WebAppSales.Data;

var builder = WebApplication.CreateBuilder(args);

// Verifique se a connection string não é nula
var connectionString = builder.Configuration.GetConnectionString("WebAppSalesContext");
if (connectionString == null)
{
    throw new InvalidOperationException("Connection string 'WebAppSalesContext' not found.");
}

// Configuração do DbContext com resiliência a erros transitórios
builder.Services.AddDbContext<WebAppSalesContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("WebAppSalesContext"),
        new MySqlServerVersion(new Version(8, 0, 23)),
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, // Número máximo de tentativas
                maxRetryDelay: TimeSpan.FromSeconds(10), // Tempo máximo de espera entre as tentativas
                errorNumbersToAdd: null // Lista de números de erro adicionais que desencadeiam uma nova tentativa
            );
        }
    )
);

// Adicione os servi�os necess�rios ao cont�iner.
builder.Services.AddControllersWithViews();

// Configurar logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
