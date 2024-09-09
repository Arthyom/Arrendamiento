﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Configuration;
using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Models.Context;

public partial class ArrendamientoContext : DbContext
{
    public ArrendamientoContext()
    {
    }

    public ArrendamientoContext(DbContextOptions<ArrendamientoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ReImpresion> ReImpresion { get; set; }
    public virtual DbSet<Renovacion> Renovacion { get; set; }
    public virtual DbSet<Arrendador> Arrendador { get; set; }

    public virtual DbSet<Arrendatario> Arrendatario { get; set; }

    public virtual DbSet<Contrato> Contrato { get; set; }

    public virtual DbSet<Fiador> Fiador { get; set; }

    public virtual DbSet<Propiedad> Propiedad { get; set; }

    public virtual DbSet<Recibo> Recibo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = config.GetConnectionString("Arrendamiento");
            optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

       

        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ReImpresion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

           
        });

        modelBuilder.Entity<Renovacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");


        });


        modelBuilder.Entity<Arrendador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Colonia).HasDefaultValueSql("'Centro'");
            entity.Property(e => e.Direccion).HasDefaultValueSql("'Benito Juarez #27'");
            entity.Property(e => e.Municipio).HasDefaultValueSql("'Moroleon'");
        });

        modelBuilder.Entity<Arrendatario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Colonia).HasDefaultValueSql("'SAMEASPROPERTY'");
            entity.Property(e => e.Direccion).HasDefaultValueSql("'SAMEASPROPERTY'");
            entity.Property(e => e.Municipio).HasDefaultValueSql("'SAMEASPROPERTY'");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Fiador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Municipio).HasDefaultValueSql("'Moroleon'");
        });

        modelBuilder.Entity<Propiedad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Municipio).HasDefaultValueSql("'Moroleon'");
        });

        modelBuilder.Entity<Recibo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}