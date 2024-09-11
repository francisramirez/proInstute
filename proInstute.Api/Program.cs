using Microsoft.EntityFrameworkCore;
using proInstute.Persistence.Context;
using proInstute.Persistence.Interfaces;
using proInstute.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<InstituteDb>(options => 
                                          options.UseSqlServer(builder.Configuration.GetConnectionString("InstituteDb")));

builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
