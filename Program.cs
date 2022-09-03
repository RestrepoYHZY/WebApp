
using Microsoft.EntityFrameworkCore;
using WebApp.Configurations;
using WebApp.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//llamamos al metodo que retorna la conexion a la base de datos 
builder.Services.DataBaseConfiguration();

//sintaxis  para configurar la conexion a la base de datos 
/*builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("data source=DUBAN;initial catalog=gestionPedidos; user id=sa; password=123;MultipleActiveResultSets=true")
    );*/

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

app.MapControllers();

app.Run();
