using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business;
using Business.Abstracts;
using Business.DependencyResolvers.Autofac;
using Business.Tools.Exceptions;
using Core.Entities;
using Core.Utilities.Tools;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterBusinessServices();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

ServiceTool.CreateServiceProvider(builder.Services);
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
app.UseMiddleware<CustomExceptionHandlerMiddleware>();

var dbContext = ServiceTool.GetService<BusinessDbContext>();
await dbContext.Database.MigrateAsync();

app.Run();
