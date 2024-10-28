using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.AnnoucementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TravelCore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>
    ().AddEntityFrameworkStores<Context>();

builder.Services.ContainerDependencies();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddDistributedMemoryCache(); // Session i�in gerekli
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // 30 dakika s�reyle aktif
    options.Cookie.HttpOnly = true; // �erez yaln�zca sunucu taraf�ndan eri�ilebilir
    options.Cookie.IsEssential = true; // GDPR i�in gerekli
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn";  // Yetkisiz eri�imlerde buraya y�nlendirilir
    options.AccessDeniedPath = "/Login/AccessDenied";  // Yetkisiz eri�im izni yoksa buraya y�nlendirilir
});

builder.Services.AddHttpClient();

builder.Services.CustomerValidator();

builder.Services.AddControllersWithViews().AddFluentValidation();



builder.Services.AddLogging(log =>
{
    log.ClearProviders();
    log.SetMinimumLevel(LogLevel.Information);
    log.AddDebug();
});


var path = Directory.GetCurrentDirectory();
builder.Logging.AddFile($"{path}\\Logs\\Log1.txt",LogLevel.Information);

builder.Services.AddMvc(config =>
{

    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});



var app = builder.Build();

// Configure the HTTP request pipeline.





if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseSession(); // Session'� kullan
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();
