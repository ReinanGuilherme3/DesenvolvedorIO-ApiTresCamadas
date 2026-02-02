using DevIO.Api.Configurations;
using DevIO.Data;
using DevIO.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDomain();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration();