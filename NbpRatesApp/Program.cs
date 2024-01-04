using Microsoft.EntityFrameworkCore;
using NbpRates.Database;
using NbpRates.Infrastructure.Factories;
using NbpRates.Infrastructure.Factories.Interfaces;
using NbpRates.Infrastructure.Repositories;
using NbpRates.Infrastructure.Repositories.Interfaces;
using NbpRatesApp.Clients;
using NbpRatesApp.Clients.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<INbpClient, NbpClient>();
builder.Services.AddTransient<IRatesRepository, RatesRepository>();
builder.Services.AddTransient<IRateFactory, RateFactory>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddDbContext<NbpRatesDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("NbpRates");
    options.UseSqlServer(connectionString);
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

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

app.Run();
