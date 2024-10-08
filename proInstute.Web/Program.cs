using Microsoft.EntityFrameworkCore;
using proInstute.Persistence.Context;
using proInstute.Persistence.Interfaces;
using proInstute.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<InstituteDb>(options =>
                                          options.UseSqlServer(builder.Configuration.GetConnectionString("InstituteDb")));

builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();



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
