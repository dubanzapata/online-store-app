using OlineStore.Dto.Models;
using OnlineStore.Infraestructura;
using OnlineStoreApp.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.DataBaseConfiguration();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddCors();


var app = builder.Build();

app.UseCors(x=> {

    x.AllowAnyHeader();
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    });

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
