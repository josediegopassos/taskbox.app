using Microsoft.OpenApi.Models;
using TaskBox.Infra.Data.Context;
using TaskBox.Infra.CossCutting.IoC;
using TaskBox.Api.Configurations.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

var envName = builder.Configuration.GetSection("EnvironmentName").Value;
var versionName = builder.Configuration.GetSection("VersionName").Value;

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.CustomSchemaIds(type => type.ToString());

    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = versionName,
        Title = $"TaskBox API - {envName}",
        Description = "Servicos da Plataforma TaskBox",
    });
});

//builder.Services.AddDbContext<TaskBoxDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.AddAutoMapperSetup();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "TaskBox.Api"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
