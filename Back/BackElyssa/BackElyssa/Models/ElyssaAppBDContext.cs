using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackElyssa.Models
{
    public partial class ElyssaAppBDContext : DbContext
    {
        public ElyssaAppBDContext()
        {
        }

        public ElyssaAppBDContext(DbContextOptions<ElyssaAppBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ElyssaAccount> ElyssaAccounts { get; set; } = null!;
        public virtual DbSet<HistoryClimate> HistoryClimates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=usuario;Database=ElyssaAppBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElyssaAccount>(entity =>
            {
                entity.HasKey(e => e.IdAcElyssa)
                    .HasName("PK__ElyssaAc__F8A8C508E0E569DA");

                entity.ToTable("ElyssaAccount");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.SurName).IsUnicode(false);
            });

            modelBuilder.Entity<HistoryClimate>(entity =>
            {
                entity.HasKey(e => e.IdClimate)
                    .HasName("PK__HistoryC__FA1DBA36E9EB2437");

                entity.ToTable("HistoryClimate");

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Lat).IsUnicode(false);

                entity.Property(e => e.Long).IsUnicode(false);

                entity.Property(e => e.Temperature).IsUnicode(false);

                entity.HasOne(d => d.IdAcElyssaNavigation)
                    .WithMany(p => p.HistoryClimates)
                    .HasForeignKey(d => d.IdAcElyssa)
                    .HasConstraintName("FK__HistoryCl__IdAcE__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
