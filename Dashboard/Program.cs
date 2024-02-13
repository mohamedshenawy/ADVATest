using ApplicationService.ServiceImplementation;
using AutoMapper;
using Domain.Models;
using DomainService.Context;
using DomainService.Repo;
using DomainService.UnitOfWork;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
var environmentName = builder.Environment.EnvironmentName;

//ConfigurationManager configuration = builder.Configuration;
//builder.Configuration
//    .SetBasePath(currentDirectory)
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
//    .AddEnvironmentVariables();
//ConnectionStrings connectionStrings = configuration.GetSection("connectionStrings").Get<ConnectionStrings>();

builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADVATest;Integrated Security=True;Encrypt=False", b => b.MigrationsAssembly("Dashboard")));
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<Context, Context>();
builder.Services.AddScoped(typeof(IRepo<>), typeof(RepoImplementation<>));
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

// logic services
builder.Services.AddScoped<EmployeeService, EmployeeService>();
builder.Services.AddScoped<DepartmentService, DepartmentService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Environment.ContentRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
app.UseStaticFiles();
app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
