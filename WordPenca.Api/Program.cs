using Microsoft.EntityFrameworkCore;
using WordPenca.Api.Hubs;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;
using WordPenca.Business.Repository.Implementation;
using WordPenca.Business.Repository.Interface;





var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IEquipoRepository, EquipoRepository>();
//builder.Services.AddScoped<IClasificacionRepository, ClasificacionRepository>();
//builder.Services.AddScoped<IPartidoRepository, PartidoRepository>();
//builder.Services.AddScoped<ITablaRepository, TablaRepository>();
//builder.Services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
//builder.Services.AddScoped<IChatHistorialRepository, ChatHistorialRepository>();
//builder.Services.AddScoped<IChatRepository, ChatRepository>();
//builder.Services.AddScoped<IChatMensajeRepository, ChatMensajeRepository>();



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




var app = builder.Build();



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}



app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAngularLocalhost");

app.UseHttpsRedirection();

//app.ConfigureExceptionHandler();

app.UseAuthorization();

app.MapHub<MessageHub>("/hubs/chat");

app.MapControllers();



app.Run();
