using CRUD.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<EmpDBContext>(item => item.UseSqlServer(builder.Configuration["ConnectionString:dbsc"]));


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
    // pattern: "{controller=EmployeeDBsController}/{action=EmployeeDBs}/{id?}");
   pattern: "{controller=Home}/{action=Index}/{id?}");
   // pattern: "{controller=Home}/{action=EmployeesDBs}/{id?}");

app.Run();
