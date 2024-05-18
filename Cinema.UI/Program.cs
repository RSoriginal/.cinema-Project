using Cinema.Core.Domain.Entities;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.Core.ServiceContracts.DTO.Services;
using Cinema.Infrastructure.DBContext;
using Cinema.UI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using StoreUI.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Cinema.Infrastructure")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<CinemaUser, CinemaRole>(options => 
{ 
    options.SignIn.RequireConfirmedAccount = false; 
    options.SignIn.RequireConfirmedEmail = false; 
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddDefaultUI();

builder.Services.AddRazorPages();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<ISeanceService, SeanceService>();

builder.Services.AddTransient<IEmailSender, SmtpEmailSender>((x) =>
{
    return new SmtpEmailSender(
    (int)(builder.Configuration.GetSection("SmtpCredential")?.GetValue(typeof(int), "SmtpClientPort") ?? throw new NullReferenceException("Configuration section SmtpCredential, value SmtpClientPort returned null")),
    (string)(builder.Configuration.GetSection("SmtpCredential")?.GetValue(typeof(string), "SmtpClientHost") ?? throw new NullReferenceException("Configuration section SmtpCredential, value SmtpClientHost returned null")),
    (string)(builder.Configuration.GetSection("SmtpCredential")?.GetValue(typeof(string), "Email") ?? throw new NullReferenceException("Configuration section SmtpCredential, value Email returned null")),
    (string)(builder.Configuration.GetSection("SmtpCredential")?.GetValue(typeof(string), "Password") ?? throw new NullReferenceException("Configuration section SmtpCredential, value Password returned null")),
    $"noreply@{builder.Environment.ApplicationName}.com");
});

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("Admin", policy =>
    {
        policy.RequireRole("Admin");
    });
    opts.AddPolicy("User", policy =>
    {
        policy.RequireRole("User");
    });
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.AccessDeniedPath = $"/Home";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
  name: "Admin",
  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
);

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();


app.Run();
