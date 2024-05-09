﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EksamenSem2.Models;

public partial class auden_dk_db_eksamenContext : DbContext
{
    public auden_dk_db_eksamenContext()
    {
    }

    public auden_dk_db_eksamenContext(DbContextOptions<auden_dk_db_eksamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kompetence> Kompetences { get; set; }

    public virtual DbSet<Medarbejder> Medarbejders { get; set; }

    public virtual DbSet<PlanDatum> PlanData { get; set; }

    public virtual DbSet<Rolle> Rolles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=mssql12.unoeuro.com;Initial Catalog=auden_dk_db_eksamen;User ID=auden_dk;Password=5pFwR4c9bfEDGe3Bdymh");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kompetence>(entity =>
        {
            entity.HasKey(e => e.KompetenceId).HasName("PK__Kompeten__C3CB8777E9E9E9E8");
        });

        modelBuilder.Entity<Medarbejder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medarbej__1707B576E1F55D7B");

            entity.HasOne(d => d.Rolle).WithMany(p => p.Medarbejders).HasConstraintName("FK__Medarbejd__Rolle__6E01572D");

            entity.HasMany(d => d.Kompetences).WithMany(p => p.Medarbejders)
                .UsingEntity<Dictionary<string, object>>(
                    "MedarbejderKompetence",
                    r => r.HasOne<Kompetence>().WithMany()
                        .HasForeignKey("KompetenceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Medarbejd__Kompe__7B5B524B"),
                    l => l.HasOne<Medarbejder>().WithMany()
                        .HasForeignKey("MedarbejderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Medarbejd__Medar__7A672E12"),
                    j =>
                    {
                        j.HasKey("MedarbejderId", "KompetenceId").HasName("MedarbejderKompetence_ID");
                        j.ToTable("MedarbejderKompetence");
                        j.IndexerProperty<int>("MedarbejderId").HasColumnName("Medarbejder_ID");
                        j.IndexerProperty<int>("KompetenceId").HasColumnName("Kompetence_ID");
                    });
        });

        modelBuilder.Entity<PlanDatum>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PK__PlanData__9BAF9B23ACACCC69");
        });

        modelBuilder.Entity<Rolle>(entity =>
        {
            entity.HasKey(e => e.RolleId).HasName("PK__Rolle__D12F04A365593430");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}