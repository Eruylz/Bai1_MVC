using Bai1.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Bai1DbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionString"]);
},
    ServiceLifetime.Scoped
);

// Add services to the container.
builder.Services.AddControllersWithViews();
ExcelPackage.LicenseContext = LicenseContext.Commercial;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
