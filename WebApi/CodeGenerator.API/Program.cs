using CodeGenerator.CORE;
using CodeGenerator.CORE.Services;
using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models;
using CodeGenerator.INFRA.DynamicDbContext;
using CodeGenerator.INFRA.Interfaces;
using CodeGenerator.INFRA.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICodeGeneratorService, CodeGeneratorService>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IGenerateFolderService, GenerateFolderService>();
builder.Services.AddScoped<IGenerateFileService, GenerateFileService>();
builder.Services.AddScoped<ITypeConverterService, TypeConverterService>();
builder.Services.AddScoped<DynamicDbContext>();
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<IPathService, PathService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
