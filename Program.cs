using perla_metro_main_api.Service;
using perla_metro_main_api.src.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IStationService, StationService>();


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
