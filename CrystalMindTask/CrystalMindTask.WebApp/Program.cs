using CrystalMindTask.Repo;
using CrystalMindTask.WebApp.Helpers;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;
var configURLs = new ConfigURLs();
configuration.GetSection("ConfigURLs").Bind(configURLs);
// Add services to the container.
builder.Services.AddRazorPages();
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
     app.MapControllers();

app.Run();
