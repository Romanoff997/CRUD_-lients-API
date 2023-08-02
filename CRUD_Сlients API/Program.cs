using CRUD_Ñlients_API.Controllers;
using CRUD_Ñlients_API.Middleware;
using CRUD_Ñlients_API.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages(); 
builder.Services.AddTransient<ClientController>();
builder.Services.AddTransient<ClientApiService>();
builder.Services.AddAntiforgery(options => options.HeaderName = "RequestVerificationToken");
builder.Services.AddSingleton<IJsonConverter>(provider => {

    return new JsonNewtonConverter();
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}");

app.Run();
