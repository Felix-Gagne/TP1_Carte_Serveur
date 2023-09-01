using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Services;
using Super_Cartes_Infinies.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer(connectionString);
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injection de dépendance
builder.Services.AddScoped<PlayersService>();
builder.Services.AddScoped<IPlayersService, PlayersService>();
builder.Services.AddSingleton<WaitingUserService>();
builder.Services.AddScoped<MatchesService>();

//Ajout de la permission des cookies
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAlmostAll", policy =>
    {
        //Spécifier les origines autorisés
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200");

        policy.AllowAnyHeader();
        policy.AllowAnyMethod();

        //Permettre l'utilisation des cookies
        policy.AllowCredentials();
    });
});


//Mettre HttpOnly false pour angular
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = false;
});

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAlmostAll");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

