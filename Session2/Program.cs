using Session2.common.middlewares;
using Session2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*
builder.Services.AddResponseCaching(options=>
{
        options.MaximumBodySize =102400;
});
*/
//Add Memcache
builder.Services.AddMemoryCache();

builder.Services.AddTransient<IHelloService, HelloService>();
builder.Services.AddSingleton<VCBBankingService, VCBBankingService>();
builder.Services.AddTransient<VIBBankingService, VIBBankingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

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
