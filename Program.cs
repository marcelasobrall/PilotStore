using PilotStore_.Services;
using Microsoft.EntityFrameworkCore;
using PilotStore_.Data;
using PilotStore_.Services.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Marcas");

});

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddDbContext<PilotStoreDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<PilotStoreDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

    options.Lockout.MaxFailedAccessAttempts = 30;
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var context = new PilotStoreDbContext();
context.Database.Migrate();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
