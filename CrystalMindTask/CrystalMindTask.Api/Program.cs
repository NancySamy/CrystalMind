using CrystalMindTask.Application;
using CrystalMindTask.Application.Customer.Commands.CreateCustomer;
using CrystalMindTask.Application.Customer.Commands.DeleteCustomer;
using CrystalMindTask.Application.Customer.Commands.UpdateCustomer;
using CrystalMindTask.Application.Customer.Queries.GetCustomer;
using CrystalMindTask.Repo;
using CrystalMindTest.infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("CrystalMindTaskDbConnection");
// Inject ContextRepo and its own Interface     
builder.Services.AddInfrastructure(connectionString!);
builder.Services.AddApplication();
// Inject the Mediator to be used in  
builder.Services.AddMediatR(typeof(GetCustomerQuery).Assembly);
builder.Services.AddMediatR(typeof(UpdateCustomerCommand).Assembly);

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
