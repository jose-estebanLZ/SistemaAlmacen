using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaAlmacen.Models.spModels;

namespace SistemaAlmacen.Models;

public partial class SistemaAlmacenDbContext : DbContext
{
    public SistemaAlmacenDbContext()
    {
    }

    public SistemaAlmacenDbContext(DbContextOptions<SistemaAlmacenDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<pObtenerProductos> ObtenerProductos { get; set; }
    public virtual DbSet<pValidarInicioSesion> ValidarInicioSesion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=estebandevserver.database.windows.net;Database=SistemaAlmacen;User Id=jose;Password=c0PJkpawoSXHcm;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<pObtenerProductos>().HasNoKey();
        modelBuilder.Entity<pValidarInicioSesion>().HasNoKey();
        
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId)
                .HasName("PK__Categori__F353C1E50966E3A6")
                .HasFillFactor(99);

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId)
                .HasName("PK__Producto__A430AEA3A36494A7")
                .HasFillFactor(99);

            entity.ToTable("Producto");

            entity.Property(e => e.Codigo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
