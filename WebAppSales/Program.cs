using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAppSales.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAppSalesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppSalesContext") ?? throw new InvalidOperationException("Connection string 'WebAppSalesContext' not found.")));

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
