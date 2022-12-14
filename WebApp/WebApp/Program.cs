
using Microsoft.EntityFrameworkCore;
using WebApp.Configurations;
using WebApp.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//llamamos al metodo que retorna la conexion a la base de datos 
builder.Services.DataBaseConfiguration();

builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(Program));




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(option =>
{
    option.AllowAnyOrigin();
    option.AllowAnyMethod();
    option.AllowAnyHeader();
});

//comentamos estas lineas para no tener probles ya que nuestro servidor esta en la  nube

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();