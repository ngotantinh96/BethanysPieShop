var builder = WebApplication.CreateBuilder(args);

//Service registration
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Middle ware configuration
app.UseStaticFiles();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
