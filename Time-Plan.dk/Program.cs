using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Time_Plan.dk.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Time_PlandkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Time_PlandkContext") ?? throw new InvalidOperationException("Connection string 'Time_PlandkContext' not found.")));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/LogIn/LogInPage";
});
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.AccessDeniedPath = "/Account/AccesDenied";
});

builder.Services.AddRazorPages(options =>
{
    // Add authorization options
    options.Conventions.AuthorizePage("/Admin/Index");
    options.Conventions.AuthorizePage("/Admin/Create");
    options.Conventions.AuthorizePage("/AShift/Oversigt");
    options.Conventions.AuthorizePage("/Ashift/Create");
    options.Conventions.AuthorizePage("/Admin/Edit");
    options.Conventions.AuthorizePage("/Admin/Delete");
    options.Conventions.AuthorizePage("/AShift/Index");
    options.Conventions.AuthorizePage("/AShift/Edit");
    options.Conventions.AuthorizePage("/AShift/Delete");

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
