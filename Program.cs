using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppChurrasco.Areas.Identity.Data;
using WebAppChurrasco.Data;
using WebAppChurrasco.Interfaces;
using WebAppChurrasco.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebAppChurrascoContextConnection") ?? throw new InvalidOperationException("Connection string 'WebAppChurrascoContextConnection' not found.");

builder.Services.AddDbContext<WebAppChurrascoContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<WebAppChurrascoUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<WebAppChurrascoContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IChurrascoRepository, ChurrascoRepository>();
builder.Services.AddScoped<IParticipantesRepository, ParticipantesRepository>();
builder.Services.AddScoped<IAgendaChurrasRepository, AgendaChurrasRepository>();
builder.Services.AddScoped<WebAppChurrascoUser, WebAppChurrascoUser>();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    name: "AgendaChurrasco",
    pattern: "{controller=Home}/{action=AgendaChurrasco}");
app.MapControllerRoute(
    name: "NovoChurrasco",
    pattern: "{controller=Home}/{action=NovoChurrasco}");
app.MapControllerRoute(
    name: "AcaoParticipantesChurras",
    pattern: "{controller=Home}/{action=AcaoParticipantesChurras}/{id?}");
app.MapControllerRoute(
    name: "DetalhesAgendaChurras",
    pattern: "{controller=Home}/{action=DetalhesAgendaChurras}/{id?}");
app.MapControllerRoute(
    name: "RemoverParticipantes",
    pattern: "{controller=Home}/{action=RemoverParticipantes}/{id?}");

app.MapRazorPages();
app.Run();
