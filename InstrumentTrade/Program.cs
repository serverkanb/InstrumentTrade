using InstrumenShop.EntityLayer.Entities;
using InstrumentShop.BusinessLayer.Abstract;
using InstrumentShop.BusinessLayer.Concrete;
using InstrumentShop.DataAccessLayer.Abstract;
using InstrumentShop.DataAccessLayer.Concrete;
using InstrumentShop.DataAccessLayer.Context;
using InstrumentShop.DataAccessLayer.Repositories;
using InstrumentTrade.WebUI.SeedData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// 🧠 Identity Ayarları
// ---------------------------
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// ---------------------------
// 📦 Katmanlı Servisler
// ---------------------------
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IBannerDal, EfBannerDal>();
builder.Services.AddScoped<IBannerService, BannerManager>();

builder.Services.AddScoped<ICartItemDal, EfCartItemDal>();
builder.Services.AddScoped<ICartItemService, CartItemManager>();

builder.Services.AddScoped<ICartDal, EfCartDal>();
builder.Services.AddScoped<ICartService, CartManager>();

builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<IOrderItemDal, EfOrderItemDal>();
builder.Services.AddScoped<IOrderItemService, OrderItemManager>();

builder.Services.AddScoped<ICountryDal, EfCountryDal>();
builder.Services.AddScoped<ICountryService, CountryManager>();

builder.Services.AddScoped<ICityDal, EfCityDal>();
builder.Services.AddScoped<ICityService, CityManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();


builder.Services.AddScoped<IReviewDal, EfReviewDal>();
builder.Services.AddScoped<IReviewService, ReviewManager>();

builder.Services.AddScoped<IGenericDal<CartItem>, GenericRepository<CartItem>>();
builder.Services.AddScoped<IGenericDal<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IGenericDal<Order>, GenericRepository<Order>>();
builder.Services.AddScoped<IGenericDal<OrderItem>, GenericRepository<OrderItem>>();
builder.Services.AddScoped<IGenericDal<Contact>, GenericRepository<Contact>>();
builder.Services.AddScoped<IGenericDal<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IGenericDal<City>, GenericRepository<City>>();
builder.Services.AddScoped<IGenericDal<Country>, GenericRepository<Country>>();
builder.Services.AddScoped<IGenericDal<Banner>, GenericRepository<Banner>>();
builder.Services.AddScoped<IGenericDal<Cart>, GenericRepository<Cart>>();
builder.Services.AddScoped<IGenericDal<Review>, GenericRepository<Review>>();

// ---------------------------
// 🧱 DB Context
// ---------------------------
builder.Services.AddDbContext<AppDbContext>();

// ---------------------------
// 🔒 Global Authorization
// ---------------------------
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    //options.Filters.Add(new AuthorizeFilter(policy));
});

// ---------------------------
// 🍪 Cookie Ayarları
// ---------------------------
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index";
  
    options.LogoutPath = "/Login/Logout";
});

var app = builder.Build();

// ---------------------------
// 🌐 Middleware
// ---------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// ---------------------------
// 🌍 Routing
// ---------------------------
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapDefaultControllerRoute();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

//---------------------------
// //🧪 Rol Seeding(Admin, Customer)
// ---------------------------
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

    string[] roles = { "Admin", "Customer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new AppRole { Name = role });
        }
    }
}
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

    await IdentityInitializer.SeedRolesAndUsersAsync(userManager, roleManager);
}


app.Run();
