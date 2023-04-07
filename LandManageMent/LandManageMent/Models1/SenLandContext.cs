using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LandManageMent.Models1;

public partial class SenLandContext : DbContext
{
    public SenLandContext()
    {
    }

    public SenLandContext(DbContextOptions<SenLandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<LandTable> LandTables { get; set; }

    public virtual DbSet<Oner> Oners { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =(local); database = SenLand;uid=hoang;pwd=123;Trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.ToTable("Agency");

            entity.Property(e => e.AgencyId).HasColumnName("agency_id");
            entity.Property(e => e.AgencyName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("agency_name");
            entity.Property(e => e.AgencyPhone)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("agency_phone");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("password");
        });

        modelBuilder.Entity<LandTable>(entity =>
        {
            entity.HasKey(e => e.LandId);

            entity.ToTable("Land_table");

            entity.Property(e => e.LandId).HasColumnName("land_id");
            entity.Property(e => e.LandName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("land_name");
            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("location");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Oner>(entity =>
        {
            entity.ToTable("Oner");

            entity.Property(e => e.OnerId).HasColumnName("oner_id");
            entity.Property(e => e.Dob).HasColumnType("date");
            entity.Property(e => e.LandId).HasColumnName("land_id");
            entity.Property(e => e.OnerName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("oner_name");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("phone");

            entity.HasOne(d => d.Land).WithMany(p => p.Oners)
                .HasForeignKey(d => d.LandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Oner_Land_table");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ResId).HasName("PK_Reservation_1");

            entity.ToTable("Reservation");

            entity.Property(e => e.ResId).HasColumnName("res_id");
            entity.Property(e => e.AgencyId).HasColumnName("agency_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.LandId).HasColumnName("land_id");
            entity.Property(e => e.OnerId).HasColumnName("oner_id");

            entity.HasOne(d => d.Agency).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Agency");

            entity.HasOne(d => d.Land).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.LandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Land_table");

            entity.HasOne(d => d.Oner).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Oner");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
