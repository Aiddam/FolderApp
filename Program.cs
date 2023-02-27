using FolderTestApp.Data;
using FolderTestApp.Extensions;
using FolderTestApp.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("ApplicationDbContext");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

app.ConfigureExceptionHandler();

app.UseHsts();
app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Instructions}/{id?}");

app.Run();
