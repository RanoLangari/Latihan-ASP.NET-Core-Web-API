using System;
using System.Collections.Generic;
using CRUD_ASP.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CRUD_ASP.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBarang> TblBarangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=crud_asp;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TblBarang>(entity =>
        {
            entity.HasKey(e => e.IdBarang).HasName("PRIMARY");

            entity.ToTable("tbl_barang");

            entity.Property(e => e.IdBarang)
                .HasColumnType("int(11)")
                .HasColumnName("id_barang");
            entity.Property(e => e.KategoriBarang)
                .HasMaxLength(255)
                .HasColumnName("kategori_barang");
            entity.Property(e => e.KeteranganBarang)
                .HasColumnType("text")
                .HasColumnName("keterangan_barang");
            entity.Property(e => e.NamaBarang)
                .HasMaxLength(255)
                .HasColumnName("nama_barang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
