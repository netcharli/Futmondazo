﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futmondazo.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Futmondazo.Models;

namespace Futmondazo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerMovement> PlayerMovements { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerHistory> PlayerHistories { get; set; }
        public DbSet<Puntuation> Puntuations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            new PlayerMovementMap(builder.Entity<PlayerMovement>());
            new ChampionshipMap(builder.Entity<Championship>());
            new PlayerHistoryMap(builder.Entity<PlayerHistory>());
            new PuntuationMap(builder.Entity<Puntuation>());
        }

        
    }
}
