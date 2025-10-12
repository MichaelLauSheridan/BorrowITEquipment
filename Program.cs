using Microsoft.EntityFrameworkCore;
using BorrowITEquip.Data;
using BorrowITEquip.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<FastEquipmentContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FastEquipmentDb")));

// Repositories
builder.Services.AddScoped<IEquipmentRepository, EFEquipmentRepository>();
builder.Services.AddScoped<IRequestRepository, EFRequestRepository>();

var app = builder.Build();

// (optional) simple dev-time migration apply
using (var scope = app.Services.CreateScope())
{
    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    if (env.IsDevelopment())
    {
        var db = scope.ServiceProvider.GetRequiredService<FastEquipmentContext>();
        db.Database.Migrate();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
