using BLL.DLL;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using BLL.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//create customer settings and add it there - in future please use this from customer settings/app settings
string connectionString = "Server=(localdb)\\mssqllocaldb;Database=StudentsDB;Trusted_Connection=True;";

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentsDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IGenericService<Student, StudentModel>, StudentServiceImpl>();


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
