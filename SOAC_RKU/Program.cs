using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SOAC_RKU.Data;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SOAC_RKUContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("soac") ?? throw new InvalidOperationException("Connection string 'soac' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(o =>
    o.IdleTimeout = TimeSpan.FromMinutes(3600)
) ;
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();





var app = builder.Build();
app.UseSession();

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
