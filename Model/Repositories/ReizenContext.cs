//using System;
//using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Microsoft.Extensions.Configuration;
using Model.Repositories.Configurations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Model.Repositories;

public partial class ReizenContext : DbContext
{

    public static IConfigurationRoot configuration = null!;
    bool testMode = false;
    public ReizenContext()
    {
    }

    public ReizenContext(DbContextOptions<ReizenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bestemming> Bestemmingen { get; set; }

    public virtual DbSet<Boeking> Boekingen { get; set; }

    public virtual DbSet<Klant> Klanten { get; set; }

    public virtual DbSet<Land> Landen { get; set; }

    public virtual DbSet<Reis> Reizen { get; set; }

    public virtual DbSet<Werelddeel> Werelddelen { get; set; }

    public virtual DbSet<Woonplaats> Woonplaatsen { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var connectionString = configuration.GetConnectionString("ReizenConnection");

            if (connectionString != null)
            {
                optionsBuilder.UseSqlServer(connectionString
                    , options => options.MaxBatchSize(150))
                    .LogTo(Console.WriteLine
                    , new[] { Command.Name }
                    , Microsoft.Extensions.Logging.LogLevel.Information
                    , Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.Level |
                    Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.LocalTime)
                    .EnableSensitiveDataLogging(true)
                    .UseLazyLoadingProxies();
            }
        }
        else
        {
            testMode = true;
        }
    }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BestemmingConfiguration());
        modelBuilder.ApplyConfiguration(new BoekingConfiguration());
        modelBuilder.ApplyConfiguration(new KlantConfiguration());
        modelBuilder.ApplyConfiguration(new LandConfiguration());
        modelBuilder.ApplyConfiguration(new ReisConfiguration());
        modelBuilder.ApplyConfiguration(new WerelddeelConfiguration());
        modelBuilder.ApplyConfiguration(new WoonplaatsConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
