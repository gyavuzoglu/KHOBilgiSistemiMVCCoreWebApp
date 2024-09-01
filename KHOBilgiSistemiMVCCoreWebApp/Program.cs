using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; //email onaylayacak mýyýz Hayýr
    options.User.RequireUniqueEmail = true; // benzersiz email adresi olsun
    options.Password.RequireUppercase = false; //þifre de büyük harf þart deðil
    options.Password.RequireLowercase = false; //þifre de küçük harf þart deðil
    options.Password.RequireDigit = false; //þifre de rakam þart deðil
    options.Password.RequiredLength = 6; //þifre uzunluðu 6 karakter olsun


});


//builder.Services.AddSession(); //***

builder.Services.AddMvc(config => //***Bütün projeyi authoizeye açma
{
    var policy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
//***

//builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    x.LoginPath = "/Kullanicilar/Login" //auth. olmadýysa Nereye gidilirse gidilsin login ekraný gelir.
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
/*app.UseSession();*/ //***
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
