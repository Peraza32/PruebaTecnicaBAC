using Microsoft.EntityFrameworkCore;
using VentasDemo.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddScoped<VentasDemo.Repository.ProductRepository>();
builder.Services.AddScoped<VentasDemo.Services.Interfaces.IProductService, VentasDemo.Services.ProductService>();
builder.Services.AddScoped<VentasDemo.Repository.SaleRepository>();
builder.Services.AddScoped<VentasDemo.Repository.SalesDetailsRepository>();
builder.Services.AddScoped<VentasDemo.Services.Interfaces.ISalesService, VentasDemo.Services.SalesService>();
builder.Services.AddScoped<VentasDemo.Services.Interfaces.ISalesDetailsService, VentasDemo.Services.SalesDetailsService>();

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
