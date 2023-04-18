using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using System;
using Infrastructure.DataAccess.Seed;
using Infrastructure.Email.Customs;
using Microsoft.AspNetCore.Identity.UI.Services;
using Infrastructure.Email.Config;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();

var emailSenderConfig = builder.Configuration.GetSection("EmailSender").Get<EmailConfig>();

builder.Services.AddSingleton(emailSenderConfig);
builder.Services.AddTransient<IEmailSender, CustomEmailSender>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
}).AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddHttpClient("rapidapi", c =>
{
    c.BaseAddress = new Uri("https://moviesdatabase.p.rapidapi.com");
    c.DefaultRequestHeaders.Add("X-RapidAPI-Key", "fdcfdb9d98mshf0a8ac4934e1a88p138684jsn90c0b90433f3");
    c.DefaultRequestHeaders.Add("X-RapidAPI-Host", "moviesdatabase.p.rapidapi.com");
}
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

    DbSeeder.Seed(dbContext, userManager, roleManager);
}
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
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboards}/{action=Dashboard_1}");
});

app.MapRazorPages();

app.Run();
