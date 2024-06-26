using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using EksamenSem2.Services.EFCore;

var builder = WebApplication.CreateBuilder(args);





var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<auden_dk_db_eksamenContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Kalender");
    options.Conventions.AuthorizePage("/GetAllMedarbejderer");
    options.Conventions.AuthorizePage("/Tilf�jMedarbejder");
});

builder.Services.AddSingleton<IVagtPlanDataService, EFCoreVagtPlanDataService>();
builder.Services.AddSingleton<IMedabejderDataService, EFCoreMedarbejderDataService>();

builder.Services.AddSingleton<IKompetenceDataService, EFCoreKompetenceDataService>();
builder.Services.AddSingleton<IRolleDataService, EFCoreRolleDataService>();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/LogIn/LogInPage";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Enables cookie-based Authentication
app.UseAuthorization();

app.MapRazorPages();

app.Run();
