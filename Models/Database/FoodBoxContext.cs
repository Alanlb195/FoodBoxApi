using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodBoxApi.Models.Database
{
    public partial class FoodBoxContext : DbContext
    {
        public FoodBoxContext()
        {
        }

        public FoodBoxContext(DbContextOptions<FoodBoxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Producto> Producto { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursal { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=Localhost;database=foodboxdb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_spanish_ci")
                .HasCharSet("utf8mb4");

            // TABLA CATEGORIA

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.CategoriaId)
                    .HasColumnType("int(8) unsigned zerofill")
                    .HasColumnName("categoriaId");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .HasColumnName("nombre");
            });

            // TABLA PRODUCTO

            modelBuilder.Entity<Producto>(entity =>
            {

                entity.ToTable("producto");

                entity.HasIndex(e => e.CategoriaId, "ProductoCATGID-CategId");

                entity.HasIndex(e => e.SucursalId, "ProductoSCID-SucursalID");

                entity.Property(e => e.ProductoId)
                    .HasColumnType("int(8) unsigned zerofill")
                    .HasColumnName("productoId");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreImagen)
                    .HasMaxLength(50)
                    .HasColumnName("nombreImagen");

                entity.Property(e => e.Precio)
                    .HasColumnType("int(5)")
                    .HasColumnName("precio");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                // Relaciones de la tabla con otras

                entity.Property(e => e.SucursalId)
                    .HasColumnType("int(8) unsigned zerofill")
                    .HasColumnName("sucursalId");

                entity.Property(e => e.CategoriaId)
                    .HasColumnType("int(8) unsigned zerofill")
                    .HasColumnName("categoriaId");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("ProductoCATGID-CategId");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.SucursalId)
                    .HasConstraintName("ProductoSCID-SucursalID");
            });

            // TABLA SUCURSAL

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.SucursalId)
                    .HasName("PRIMARY");

                entity.ToTable("sucursal");

                entity.Property(e => e.SucursalId)
                    .HasColumnType("int(8) unsigned zerofill")
                    .HasColumnName("sucursalId");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .HasColumnName("nombre");

                entity.Property(e => e.Horario)
                    .HasMaxLength(15)
                    .HasColumnName("horario");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .HasColumnName("ubicacion");

                entity.Property(e => e.UbicacionAdc)
                    .HasMaxLength(50)
                    .HasColumnName("ubicacionAdc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
