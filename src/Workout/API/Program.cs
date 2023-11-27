using API;
using API.Endpoints;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors();

app.UseExceptionHandler(options => { });

app.MapGroup("api/v1/workout")
    .MapWorkouts();

app.MapGroup("api/v1/workoutType")
    .MapWorkoutTypes();

app.UseAuthentication();
app.UseAuthorization();

app.Run();