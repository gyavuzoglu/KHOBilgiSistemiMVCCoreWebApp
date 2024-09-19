using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.AutoMappers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; //email onaylayacak mýyýz Hayýr
    options.User.RequireUniqueEmail = true; // benzersiz email adresi olsun
    options.Password.RequireUppercase = false; //þifre de büyük harf þart deðil
    options.Password.RequireNonAlphanumeric=false;//þifre de alfanümeraik zorunlu deðil
    options.Password.RequireLowercase = false; //þifre de küçük harf þart deðil
    options.Password.RequireDigit = false; //þifre de rakam þart deðil
    options.Password.RequiredLength = 6; //þifre uzunluðu en az 6 karakter olsun

});

//AutoMapper daki her profil böyle Eklendi.
builder.Services.AddAutoMapper(typeof(PersonelProfile));


builder.Services.AddSession(); //***
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUserTbl, AppRolesTbl>().AddEntityFrameworkStores<Context>();

builder.Services.AddMvc(config => //***Bütün projeyi authorizeye açma
{
    var policy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
//***

//builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    x.LoginPath = "/Home/Index" //auth. olmadýysa Nereye gidilirse gidilsin login ekraný gelir.
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); //***
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "Areas",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
//Genel Area Path Tanýmý böyle ama biz ayrý ayrý path tanýmý yapýyoruz. 

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
      name: "Yonetim",
      areaName:"YonetimArea",
      pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
      name: "Ogrenci",
      areaName: "OgrenciArea",
      pattern: "ogrenci/{controller=Home}/{action=Index}/{id?}"
    );
});

//Yukarýdaki area tanýmlarý her yeni area eklendikçe oluþturulacak.


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
