using Microsoft.EntityFrameworkCore;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;
using WordPenca.Business.Repository.Implementation;
using WordPenca.Business.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PencaDeportes"),
    b => b.MigrationsAssembly("WordPenca.Backoffice")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<IEquipoRepository, EquipoRepository>();
//builder.Services.AddTransient<IClasificacionRepository, ClasificacionRepository>();
//builder.Services.AddTransient<IPartidoRepository, PartidoRepository>();
//builder.Services.AddTransient<ITablaRepository, TablaRepository>();
//builder.Services.AddTransient<ICampeonatoRepository, CampeonatoRepository>();


builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
