using _1_Application.Data;
using Microsoft.EntityFrameworkCore;
using _1_Application.Repo;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// register DbContext using Pomelo MySQL provider
builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySql(connectionString,
    new MySqlServerVersion(new Version(8, 0, 36))));


builder.Services.AddScoped<ITagRepository, TagRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();


//adding some comments
//adding some more commits
/*





csdjbvhdsvhsbvjhdsvhjdsvjhdsvjhdsvjhdsvhjds



*/
