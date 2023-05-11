using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Core;
using Infrastructure.DataAccess.Seed;
using Microsoft.AspNetCore.Identity.UI.Services;
using Infrastructure.Email.Config;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Application.Services;
using QRCoder;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces.AppInterfaces;
using Domain.Interfaces.Repository;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.Email.Customs.Interface;
using Infrastructure.Email.Customs.Concrete;
using AutoMapper;
using Application.Services.Mappings;
using Cinemagnesia.Presentation.Mappings;
using Microsoft.Extensions.Options;
using FluentValidation;
using Domain.Entities.Concrete;
using Cinemagnesia.Presentation.Validation;
using Cinemagnesia.Presentation.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();

var emailSenderConfig = builder.Configuration.GetSection("EmailSender").Get<EmailConfig>();

builder.Services.AddSingleton(emailSenderConfig);
builder.Services.AddTransient<ICustomEmailSender, CustomEmailSender>();
builder.Services.AddSingleton(new QRCodeService(new QRCodeGenerator()));
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ICastMemberRepository, CastMemberRepository>();
builder.Services.AddScoped<ICastMemberService, CastMemberService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IDirectorService, DirectorService>();
builder.Services.AddScoped<IMovieCommentRepository, MovieCommentRepository>();
builder.Services.AddScoped<IMovieCommentService, MovieCommentService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddTransient<IValidator<AddMovieViewModel>, AddMovieViewModelValidator>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IProductorRequestRepository, ProductorRequestRepository>();
builder.Services.AddScoped<IProductorRequestService, ProductorRequestService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IWatchListRepository, WatchListRepository>();
builder.Services.AddScoped<IWatchListService, WatchListService>();



builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
}).AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationDbContext>();


var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);





builder.Services.AddHttpClient("rapidapi", c =>
{
    c.BaseAddress = new Uri("https://moviesdatabase.p.rapidapi.com");
    c.DefaultRequestHeaders.Add("X-RapidAPI-Key", "fdcfdb9d98mshf0a8ac4934e1a88p138684jsn90c0b90433f3");
    c.DefaultRequestHeaders.Add("X-RapidAPI-Host", "moviesdatabase.p.rapidapi.com");
}
);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(GenreDtoMapper));
builder.Services.AddAutoMapper(typeof(ProductorRequestMapper));
builder.Services.AddAutoMapper(typeof(ViewModelMapper));
builder.Services.AddAutoMapper(typeof(MovieDtoMapper));
builder.Services.AddAutoMapper(typeof(WatchListDtoMapper));




builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
    {
        policy.RequireRole("User");
    });
});


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
        pattern: "Admin/{controller=Statistic}/{action=Index}").RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });
});

app.MapRazorPages();

app.Run();

