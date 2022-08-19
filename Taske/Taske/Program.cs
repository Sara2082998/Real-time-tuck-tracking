using Microsoft.EntityFrameworkCore;
using Taske.Models;
using Taske.Repos;
using Taske.Hubs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITruckRepos, TruckRepos>();
builder.Services.AddDbContext<Tracking_taskContext>(n => n.UseSqlServer(builder.Configuration.GetConnectionString("iticon")));
builder.Services.AddSignalR();

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
app.MapHub<TruckHub>("/truckhub");
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
