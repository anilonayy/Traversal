using _Traversal.CQRS.Handlers.Destination;
using _Traversal.Models.Login;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
builder.Services.AddScoped<CreateCommandHandler>();
builder.Services.AddScoped<DeleteCommandHandler>();
builder.Services.AddScoped<UpdateCommandHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));





builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.SetMinimumLevel(LogLevel.Debug);
    loggingBuilder.AddFile(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "logs", "app.log"));
    loggingBuilder.AddDebug();
});


// Add Db Context
builder.Services.AddDbContext<Context>();

// Added Dependency Containers
BusinessLayer.Container.Extensions.ContainerDependencies(builder.Services);
BusinessLayer.Container.Extensions.CustomValidator(builder.Services);

    
// Add Auto Mapper

// Add Identity Class
builder.Services
    .AddIdentity<AppUser, AppRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>(); // Özel mesajlara karþýlýk yaz.

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});

// Language Localization
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("tr");
    options.AddSupportedUICultures("tr", "en", "fr");
    options.FallBackToParentUICultures = true;
    options.RequestCultureProviders.Clear();
});

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn";
    options.AccessDeniedPath = "/Login/SignIn";
});

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");



app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();



app.UseRequestLocalization();

// If there is a selected language in cookies, it sets it.
app.UseSetSelectedCulture();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}"
);


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);



app.Run();
