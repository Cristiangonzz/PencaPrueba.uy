using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;
using WordPenca.Business.Repository.Implementation;
using WordPenca.Business.Repository.Interface;
using WordPenca.Business.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddEndpointsApiExplorer();
// Configure MongoDB settings
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));

builder.Services.AddSingleton<IMongoDB>(sp =>
    sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);


builder.Services.AddSingleton<ChatService>();
builder.Services.AddSingleton<ChatHistorialService>();
builder.Services.AddSingleton<ChatMensajeService>();
builder.Services.AddSingleton<ChatUsuarioService>();



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PencaDeportes"),
    b => b.MigrationsAssembly("WordPenca.Backoffice")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

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
