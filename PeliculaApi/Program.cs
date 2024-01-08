using Microsoft.EntityFrameworkCore;
using PeliculaApi.Utilities;
using PeliculaDb;
using PeliculaServices.Services;
using PeliculaServicesDependency.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt => 
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Db
string connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(connection);
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Services 
builder.Services
    .AddScoped<IGeneroService, GeneroServiceDependency>()
    .AddScoped<IActorService, ActorServiceDependency>();

// Response 
builder.Services.AddScoped<ResponseHttp>();

// Mapper
builder.Services.AddAutoMapper(typeof(PeliculaModel.Services.MapperProfile));

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
