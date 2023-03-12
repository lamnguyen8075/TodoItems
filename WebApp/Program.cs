using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

/*
 *  Implementing services
    Configuring dependency injection container
    used regsiter a DB context as a service
    register "TodoContext" as a service in container
    the EntityFramework will interact with data to the in-mem db instead of traditional
 */
builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

// Adding Swagger UI and JSOn to the app's middleware pipeline
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Config the HTTP operations
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
