using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Farmacity.Infrastructure.Data;
using Farmacity.Infrastructure.UnitOfWork;
using Farmacity.Infrastructure.Repositories.Interfaces;
using Farmacity.Infrastructure.Repositories.Classes;
using Farmacity.Application.Services.Interfaces;
using Farmacity.Application.Services.Classes;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
#region Services
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssembly(Assembly.Load("Farmacity.Application"));
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICodigoBarraService, CodigoBarraService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICodigoBarraRepository, CodigoBarraRepository>();

#endregion Services

var app = builder.Build();

#region Middlewares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
#endregion Middlewares

app.Run();
