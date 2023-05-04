using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Time_Plan.dk.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Time_PlandkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Time_PlandkContext") ?? throw new InvalidOperationException("Connection string 'Time_PlandkContext' not found.")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
