using DevIO.Api.Configurations;
using DevIO.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration();