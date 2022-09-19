using Microsoft.EntityFrameworkCore;
using ProEventos.Application;
using ProEventos.Application.Contract;
using ProEventos.Persistence;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProEventosContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddControllers();
// adicionado escopop para Injeção de Dependências
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IEventoPersist, EventoPersist>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader().
                AllowAnyMethod().
                AllowAnyOrigin());

app.MapControllers();

app.Run();
