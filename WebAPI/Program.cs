using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infraestructure.Repository;
using Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do DbContext
builder.Services.AddDbContext<TurismoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o do AutoMapper
builder.Services.AddAutoMapper(typeof(PontoTuristicoProfile));

// Registro de Servi�os e Reposit�rios
builder.Services.AddScoped<IPontoTuristicoService, PontoTuristicoService>();
builder.Services.AddScoped<IPontoTuristicoRepository, PontoTuristicoRepository>();

// Configura��o de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configura��o do Swagger e Controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para tratamento de erros
app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception ex)
    {

        context.Response.StatusCode = 500; // Internal Server Error
        await context.Response.WriteAsync("Um erro ocorreu. Tente novamente mais tarde.");
    }
});

// Configura��o do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitando CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
