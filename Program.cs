using Microsoft.Extensions.Caching.Memory;
using Rick_And_Morty.Data.APIObject.Character;
using Rick_And_Morty.DTO;
using Rick_And_Morty.Services;
using Rick_And_Morty.Services.Convertor;
using Rick_And_Morty.Services.Request_Service;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddTransient<IRequestService, RequestRickAndMortyAPIService>();
builder.Services.AddScoped<IConvertor<Character, CharacterDTO>, ConvertorCharacter>();
builder.Services.AddScoped<IRickAndMortyCachedService,RickAndMortyCachedService>();
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
