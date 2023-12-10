global using dotnet_rpg.Models;
global using dotnet_rpg.Services.CharacterService;
global using dotnet_rpg.Dtos.Character;
global using Microsoft.EntityFrameworkCore;
global using dotnet_rpg.Data;

using dotnet_rpg.Controllers;

var builder = WebApplication.CreateBuilder(args);

/* This line of code is configuring the dependency injection container to add a DbContext of type
`DataContext` to the services collection. It is also specifying that the DbContext should use SQL
Server as the underlying database provider, and it is retrieving the connection string named
"DefaultConnection" from the application's configuration. */
builder.Services.AddDbContext<DataContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
