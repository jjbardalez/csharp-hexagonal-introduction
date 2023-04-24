using Caba.Infraestructure.Repositories.User.CreateUser;
using MediatR;
using Npgsql;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection to database
builder.Services.AddTransient<IDbConnection>(x => new NpgsqlConnection(builder.Configuration.GetConnectionString("DB_CONN_STR")));

// User Repository
builder.Services.AddTransient(typeof(ICreateUserRepository), typeof(CreateUserRepository));

Assembly application = AppDomain.CurrentDomain.Load("Caba.Application");
builder.Services.AddMediatR(application);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
