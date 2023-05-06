using BulkyBook.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// this part is for dependency injection also.
builder.Services.AddControllersWithViews();
// we need to add in programe that we will use db contect
//and also add the connection string we will use
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    //GetConnectionString method only works if I named "ConnectionStrings" in appsettings.json file, If it's changed, it won't work 
    builder.Configuration.GetConnectionString("DefaultConnection") // defaultConnection is the name of the connection string
    ));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // this middleware is to show user friendly exceptions
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // it has to come before the auth as the user should be authenticated first then to be authorised to do smth
app.UseAuthorization(); //auth middlware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

