using System.Text;
using Microsoft.IdentityModel.Tokens;
using perla_metro_main_api.Dto;
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
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


var jwtSecret = builder.Configuration["JWT:Secret"];
if (jwtSecret == null)
{
    return;
}

Console.WriteLine(jwtSecret);

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
        };
    });

builder.Services.AddAuthorization();



var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
