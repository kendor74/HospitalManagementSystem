using HMS_API.Model;
using HMS_API.Model.DTOs;
using HMS_API.Model.Interfaces;
using HMS_API.Model.PatientHandler;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection String
var connection = builder.Configuration.GetConnectionString("Hospital");
builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(connection));


builder.Services.AddScoped<IRepo<Patient, PatientDto>, PatientHandler>();




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