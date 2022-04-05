using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Port> Ports { get; set; } = null!;
        public virtual DbSet<Ship> Ships { get; set; } = null!;
        public virtual DbSet<Voyage> Voyages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=portapidb;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<Port>(entity =>
            {
                entity.ToTable("Port");

                entity.Property(e => e.PortId)
                    .ValueGeneratedNever()
                    .HasColumnName("port_id");

                entity.Property(e => e.PortCountryId).HasColumnName("port_country_id");

                entity.Property(e => e.PortName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("port_name");

                entity.HasOne(d => d.PortCountry)
                    .WithMany(p => p.Ports)
                    .HasForeignKey(d => d.PortCountryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Port__port_count__4BAC3F29");
            });

            modelBuilder.Entity<Ship>(entity =>
            {
                entity.ToTable("Ship");

                entity.Property(e => e.ShipId)
                    .ValueGeneratedNever()
                    .HasColumnName("ship_id");

                entity.Property(e => e.ShipName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ship_name");

                entity.Property(e => e.ShipSpeedMax)
                    .HasColumnName("ship_speed_max")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Voyage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Voyage");

                entity.Property(e => e.VoyageArrivalPort).HasColumnName("voyage_arrival_port");

                entity.Property(e => e.VoyageDate)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("voyage_date");

                entity.Property(e => e.VoyageDeparturePort).HasColumnName("voyage_departure_port");

                entity.Property(e => e.VoyageEnd)
                    .HasColumnType("date")
                    .HasColumnName("voyage_end");

                entity.Property(e => e.VoyageShipId).HasColumnName("voyage_ship_id");

                entity.Property(e => e.VoyageStart)
                    .HasColumnType("date")
                    .HasColumnName("voyage_start");

                entity.HasOne(d => d.VoyageArrivalPortNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.VoyageArrivalPort)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Voyage__voyage_a__52593CB8");

                entity.HasOne(d => d.VoyageDeparturePortNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.VoyageDeparturePort)
                    .HasConstraintName("FK__Voyage__voyage_d__5165187F");

                entity.HasOne(d => d.VoyageShip)
                    .WithMany()
                    .HasForeignKey(d => d.VoyageShipId)
                    .HasConstraintName("FK__Voyage__voyage_s__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
