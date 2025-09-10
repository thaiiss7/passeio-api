using Microsoft.EntityFrameworkCore;
using Passeio.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PasseioDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var app = builder.Build();

app.Run();
