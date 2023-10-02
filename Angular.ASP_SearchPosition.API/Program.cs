using Angular.ASP_SearchPosition.Data.Extensions;
using Angular.ASP_SearchPosition.Services;
using Angular.ASP_SearchPosition.Services.Factories;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

{ // Own configuration

    // Data contexts
    builder.Services.AddDataContexts(
        builder.Configuration.GetConnectionString("Dev")!
        );

    // Http context
    builder.Services.AddHttpContextAccessor();

    // Swagger gen
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
    });

    // HttpClient factory
    builder.Services.AddHttpClient("universal", c =>
    {
        c.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        c.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
        c.DefaultRequestHeaders.AcceptLanguage.ParseAdd("en-US,en;q=0.9");
    });

    // Scraper factory
    builder.Services.AddSingleton<IScraperFactory, ScraperFactory>();

    // Log service
    builder.Services.AddScoped<IDbLoggerService, DbLoggerService>();

    // Search service
    builder.Services.AddScoped<ISearchService, SearchService>();
    // Search decorator
    builder.Services.Decorate<ISearchService, SearchServiceLogDecorator>();
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
}


{ // Own middleware
    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // CORS
    app.UseCors(
        options =>
        {
            options.WithOrigins("http://localhost:8080")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }
        );
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
