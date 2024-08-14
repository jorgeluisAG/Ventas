using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ventas.DataAccess.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseOracle("User Id=USER_CRUD;Password=soporte2024;Data Source=localhost:1521/xe;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("USER_CRUD")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("SYS_C008318");

            entity.ToTable("CLIENTES");

            entity.HasIndex(e => e.CorreoElectronico, "SYS_C008319").IsUnique();

            entity.Property(e => e.IdCliente)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("SYSDATE\n")
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<DetallesPedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("SYS_C008334");

            entity.ToTable("DETALLES_PEDIDO");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Cantidad)
                .HasPrecision(10)
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.IdPedido)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_PEDIDO");
            entity.Property(e => e.IdProducto)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_PRODUCTO");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallesPedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008335");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesPedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008336");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("SYS_C008328");

            entity.ToTable("PEDIDOS");

            entity.Property(e => e.IdPedido)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID_PEDIDO");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("FECHA_PEDIDO");
            entity.Property(e => e.IdCliente)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Total)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008329");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("SYS_C008324");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.Precio)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Stock)
                .HasPrecision(10)
                .HasColumnName("STOCK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
