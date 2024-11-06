﻿using Farmacity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Farmacity.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<CodigoBarra> CodigosBarras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}