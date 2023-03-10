using EFCorePeliculas;
using EFCorePeliculas.CompiledModels;
using EFCorePeliculas.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opciones => 
  opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Hace que pueda reciclar las instancias de DbContext:
//builder.Services.AddDbContextPool<ApplicationDbContext>
builder.Services.AddDbContextFactory<ApplicationDbContext>(opciones =>
{
        opciones.UseSqlServer(connectionString, sqlServer => sqlServer.UseNetTopologySuite());
        opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //opciones.UseModel(ApplicationDbContextModel.Instance);
        //opciones.UseLazyLoadingProxies();
}
);

builder.Services.AddScoped<IActualizadorObservableCollection, ActualizadorObservableCollection>();
builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();
builder.Services.AddScoped<IEventosDbContext, EventosDbContext>();

//Registro de DBContext como singleton a trav?s de IServiceProvider: si se ejecuta este c?digo NO fallar?:
builder.Services.AddSingleton<ServicioSingletonCorrecto>();
//Registro de DBContext como singleton a trav?s de ApplicationDbContext: si se ejecuta este c?digo SI fallar?:
//builder.Services.AddSingleton<ServicioSingletonFallo>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
