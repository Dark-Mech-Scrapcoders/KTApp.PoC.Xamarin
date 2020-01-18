using KTApp.Core.Models;
using KTApp.Core.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTApp.Core
{
    public class KillTeamContext : DbContext
    {
        private DbOptions _options;

        public DbSet<Faction> Factions { get; set; }

        public KillTeamContext()
        {
        }

        public KillTeamContext(DbOptions options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Filename={_options.DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FactionDatasheet>(b =>
            {
                b.ToTable("faction_datasheet");
                b.HasKey(e => new { e.FactionId, e.DataSheetId });
                b.Property(e => e.FactionId).HasColumnName("faction_id");
                b.Property(e => e.DataSheetId).HasColumnName("datasheet_id");

                b.HasOne(e => e.Faction)
                .WithMany(e => e.FactionDatasheets)
                .HasForeignKey(e => e.FactionId);

                b.HasOne(e => e.DataSheet)
                .WithMany(e => e.FactionDatasheets)
                .HasForeignKey(e => e.DataSheetId);
            });

            modelBuilder.Entity<Faction>(b =>
            {
                b.ToTable("faction");
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.Property(e => e.Name).HasColumnName("faction_name");
                b.Property(e => e.Keyword).HasColumnName("faction_keyword");
            });

            modelBuilder.Entity<DataSheet>(b =>
            {
                b.ToTable("datasheet");
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();

                b.Property(e => e.Name).HasColumnName("datasheet_name")
                .HasMaxLength(80);
            });
        }
    }
}
