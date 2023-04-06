using Application.Configuration;
using DataAccess.Context;
using DataAccess.Repositories.Configuration;
using WebApi.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Norator.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NoratorContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddApplicationRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddApplicationMappers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Norator",
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});




var app = builder.Build();

app.AddApplicationMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Norator");

app.UseAuthorization();

app.MapControllers();

app.Run();
