using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Session2.common;
using Session2.common.middlewares;
using Session2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(o=>{o.ResourcesPath = "Resources";});
builder.Services.AddControllersWithViews()
        .AddViewLocalization()
        .AddDataAnnotationsLocalization();
/*
builder.Services.AddResponseCaching(options=>
{
        options.MaximumBodySize =102400;
});
*/
//Add Memcache
//builder.Services.AddMemoryCache();

builder.Services.AddDistributedSqlServerCache(options=>{
        options.ConnectionString = "Data Source=(local); Database=DistCache; User=sa; Password=123456;TrustServerCertificate=true";
        options.SchemaName = "dbo";
        options.TableName = "TestCache";
});

List<CultureInfo> supportedCultures = new List<CultureInfo>(){
        new CultureInfo("vi-VN"),
        new CultureInfo("en-GB")
};

builder.Services.Configure<RequestLocalizationOptions>(option=>{
        option.SupportedCultures = supportedCultures;
        option.SupportedUICultures = supportedCultures;
        option.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture:"vi-VN", uiCulture:"vi-VN");
});

builder.Services.AddTransient<IHelloService, HelloService>();
builder.Services.AddSingleton<VCBBankingService, VCBBankingService>();
builder.Services.AddTransient<VIBBankingService, VIBBankingService>();
builder.Services.AddTransient<CacheStorage>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRequestLocalization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseResponseCaching();

app.UseAuthorization();

//app.useApiKeyFilter();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
