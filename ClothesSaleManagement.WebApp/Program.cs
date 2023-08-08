using System.Reflection;
using ClothesSaleManagement.Infrastructure;
using ClothesSaleManagement.WebApp.Services.Bill;
using ClothesSaleManagement.WebApp.Services.Category;
using ClothesSaleManagement.WebApp.Services.Product;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Config Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
{
	opt.IdleTimeout = TimeSpan.FromMinutes(10);
	opt.Cookie.HttpOnly = true;
	opt.Cookie.IsEssential = true;
});

builder.Services.ConfigureInfrastructureService(builder.Configuration);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBillService, BillService>();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//	.AddCookie(opt =>
//	{
//		opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
//		opt.Cookie.HttpOnly = true;
//		opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//		opt.LoginPath = "/admin/auth";
//	});

builder.Services.ConfigureApplicationCookie (options => {
	options.Cookie.HttpOnly = true;  
	options.ExpireTimeSpan = TimeSpan.FromMinutes(30);  
	options.LoginPath = $"/admin/auth/";                                 // Url đến trang đăng nhập
	options.LogoutPath = $"/logout/";   

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoint =>
{
	endpoint.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Admin}/{action=Index}");

	endpoint.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
