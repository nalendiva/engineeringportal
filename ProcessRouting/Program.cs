using Microsoft.EntityFrameworkCore;
using ProcessRouting.Data;
using WorkStandar.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<WorkStandarDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WorkStandarConnection")));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ProcessRouting",
        Version = "v1",
        Description = "ApiFromMy.Net",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Ale",
            Email = "muhammadnalendraz@gmail.com",
            Url = new Uri("https://example.com")
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProcessRouting");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ProcessRouting}/{action=Index}/{id?}");

app.Run();



app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Content-Security-Policy", "script-src 'self' 'unsafe-inline'");
    await next();
});

