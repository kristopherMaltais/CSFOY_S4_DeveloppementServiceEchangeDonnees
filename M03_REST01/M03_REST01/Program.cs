using M03_REST01.Data;
using M03_REST01.SERVICE_Municipalite;
using M03_ServicesSOAP;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// INJECTION DES DÉPENDANCES
builder.Services.AddScoped<IDepotMunicipalite, DepotMunicipalite>();
builder.Services.AddScoped<ManipulationMunicipalites>();

builder.Services.AddScoped<IMunicipaliteService, MunicipaliteService>();




builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerDocument();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// CONFIGURATION
app.UseSoapEndpoint<IMunicipaliteService>("/MunicipaliteService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IMunicipaliteService>("/MunicipaliteService.asmx", new SoapEncoderOptions());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.UseOpenApi();
app.UseSwaggerUi3();
app.Run();


