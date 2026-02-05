using UserManagement.API.Extensions;
using UserManagement.API.Middlewares;
using UserManagement.Application;
using UserManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Exception handlers
builder.Services.AddExceptionHandler<GlobalExceptionHandler>()
                .AddProblemDetails();

// Swagger
builder.Services.AddSwaggerConfiguration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen();

// CORS
builder.Services.ConfigureCorsPolicy();

// Service Layers
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
//Middlewares
app.UseExceptionHandler();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.SwaggerConfig(builder.Configuration, "SwaggerConfigTest");
}
app.UseHttpsRedirection();

await app.SeedDatabaseAsync();

app.MapEndpoints();
app.Run();

