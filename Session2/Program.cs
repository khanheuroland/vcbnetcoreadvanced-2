using Session2.common.middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



app.Use(async(context, next)=> {
    await context.Response.WriteAsync("<div>Today very hot!!!</div>");
    await next.Invoke();
    await context.Response.WriteAsync("<div>Hope that, tomorrow is better!</div>");
});

app.Use(async(context, next)=> {
    await context.Response.WriteAsync("<div>Today is Session 2 of .NET Core</div>");
    await next.Invoke();
    await context.Response.WriteAsync("<div>Bye bye, see you tomorrow!</div>");
});

//Create first middleware 
app.Run(async (context) =>{
    await context.Response.WriteAsync("<div>Hello VCB, Welcome to IPMac</div>");
});

app.Use(async(context, next)=> {
    await context.Response.WriteAsync("<div>Today is Session 2 of .NET Core</div>");
    await next.Invoke();
    await context.Response.WriteAsync("<div>Bye bye, see you tomorrow!</div>");
});

app.UseMiddleware<SimpleMiddleware>();


app.Run();
