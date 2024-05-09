using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IMedabejderDataService,EFCoreMedarbejderDataService>();
builder.Services.AddRazorPages(options =>
{
    // Add authorization options
    options.Conventions.AuthorizePage("/Index");
    options.Conventions.AuthorizePage("/TilføjMedarbeder");
    options.Conventions.AuthorizePage("/GetAllMedarbederer");


});

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
