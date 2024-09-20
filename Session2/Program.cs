using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Session2.common;
using Session2.common.filters;
using Session2.common.middlewares;
using Session2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(o=>{o.ResourcesPath = "Resources";});
builder.Services.AddControllersWithViews(options=>{
        options.Filters.Add(new CustomExceptionFilter());
        }
)
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
//builder.Services.AddTransient<CacheStorage>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.AddTransient<TranslationHelper>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
}
// Configure the HTTP request pipeline.
app.UseRequestLocalization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseExceptionHandler();
//app.useApiKeyFilter();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();


