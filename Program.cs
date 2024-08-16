using CastingWebAPI;
using CastingWebAPI.Interfaces;
using CastingWebAPI.Repositories;
using CastingWebAPI.Services;
using MongoDB.Driver;
using static CastingWebAPI.Settings;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

    return new MongoClient(CONNECTION_STRING);
});
//register repositories and services for dependency injection
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IProjectRepository, ProjectRepository>();
builder.Services.AddSingleton<IPasswordService, PasswordService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
