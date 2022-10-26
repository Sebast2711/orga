using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrgaTournoi.Data;
using OrgaTournoi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrgaTournoiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrgaTournoiContext") ?? throw new InvalidOperationException("Connection string 'OrgaTournoiContext' not found.")));

// A rajouter dans le projet si non probleme avec UseAuthorization
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData2.Initialize(services);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
