using BethanysPieShop.App;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BethanysPieShopDbContextConnection' not found.");

builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<BethanysPieShopDbContext>();

//Service registration
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(ShoppingCart.GetCart);
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

//Middle ware configuration
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.UseAntiforgery();

app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

DBInitializer.Seed(app);

app.Run();
