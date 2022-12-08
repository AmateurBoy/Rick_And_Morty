using Microsoft.Extensions.Caching.Memory;
using Rick_And_Morty.DTO;
using Rick_And_Morty.Services;
using RickAndMorty.Net.Api.Models.Domain;
using System;
using MemoryCache = Rick_And_Morty.Services.MemoryCache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddTransient<MemoryCache>();
builder.Services.AddTransient<RequestHandlerAPI>();



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
