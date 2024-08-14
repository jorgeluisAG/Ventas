using Microsoft.EntityFrameworkCore;
using Ventas.DataAccess.Models;
using Ventas.Services.Implementation;
using Ventas.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Configuration ModelContext
builder.Services.AddDbContext<ModelContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("defaultConnection")));

// Registring Services
builder.Services.AddTransient<IClienteService, ClienteService>();

// Add services to the container.

builder.Services.AddControllers();
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
