using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Quartz;
using WordPenca.Api.Controllers;
using WordPenca.Api.Hubs;
using WordPenca.Api.quartz;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;
using WordPenca.Business.Repository.Implementation;
using WordPenca.Business.Repository.Interface;
using WordPenca.Business.Service;





var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Configure MongoDB settings
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));

// Register IMongoClient using the connection string from configuration
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.Server);
});


builder.Services.AddSingleton<ChatService>();
builder.Services.AddSingleton<ChatHistorialService>();
builder.Services.AddSingleton<ChatMensajeService>();
builder.Services.AddSingleton<ChatUsuarioService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllersWithViews();


builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PencaDeportes"),
    b => b.MigrationsAssembly("WordPenca.Backoffice")));

builder.Services.AddSignalR();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost",
        builder =>
        {
            builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                   .WithOrigins("https://localhost:4200", "http://localhost:4200"); // Agregar este m�todo para exponer el encabezado CORS.
        });
});


// Configure Quartz services
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey("GetMatchesJob");

    q.AddJob<GetMatchesJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("GetMatchesJob-trigger")
        .WithCronSchedule("0/10 * * * * ?")); // Every 6 seconds
});

builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});


// builder.Services.AddSingleton<GetMatchesJob>();
// builder.Services.AddHostedService<QuartzHostedService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAngularLocalhost");

app.UseHttpsRedirection();

//app.ConfigureExceptionHandler();

app.UseAuthorization();

app.MapHub<MessageHub>("/hubs/chat");

app.MapControllers();



app.Run();


