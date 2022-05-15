using CrystalMindTask.Application;
using CrystalMindTask.Repo;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("CrystalMindTaskDbConnection");
// Inject ContextRepo and its own Interface     
builder.Services.AddInfrastructure(connectionString!);
builder.Services.AddApplication();
// Add services to the container.
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
