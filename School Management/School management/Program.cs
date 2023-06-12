using Dapper;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using School_management;
using School_management.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ISignupRepository, SignupRepository>();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "Db",
//        pattern: "User/{action}/{id?}",
//        defaults: new { controller = "Home", action = "Index" }
//    );
//});

// Register your UserRepository as a service
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddTransient(x => new MySqlConnection(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddSession();




var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//For new page
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=User}/{action=Output}/{id?}",
//        defaults: new { controller = "User", action = "Output" }
//    );
//});


app.Run();
