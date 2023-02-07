using System;
using HRSystem.DAO;
using HRSystem.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<PersonInfoDAO>();
builder.Services.AddDbContext<HRDbContext>();
builder.Services.AddTransient<OnBoardingDAO>();

builder.Services.AddSwaggerGen();

builder.Services.AddLogging(loggingbuilder =>
{
    _ = loggingbuilder.AddConsole();
    _ = loggingbuilder.AddDebug();
});

WebApplication app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}
else
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
