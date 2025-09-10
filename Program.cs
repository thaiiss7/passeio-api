using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Passeio.Endpoints;
using Passeio.Models;
using Passeio.Services.JWT;
using Passeio.Services.Tour;
using Passeio.UseCases.CreateTour;
using Passeio.UseCases.EditTour;
using Passeio.UseCases.GetTour;
using Passeio.UseCases.Login;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PasseioDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddSingleton<IJWTService, JWTService>();
builder.Services.AddTransient<ITourService, EFTourService>();

builder.Services.AddTransient<CreateTourUseCase>();
builder.Services.AddTransient<EditTourUseCase>();
builder.Services.AddTransient<GetTourUseCase>();
builder.Services.AddTransient<LoginUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "passeio-api",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureAuthEndpoints();
app.ConfigureTourEndpoints();

app.Run();
