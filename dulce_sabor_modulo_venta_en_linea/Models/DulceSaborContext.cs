using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class DulceSaborContext : DbContext
{
    public DulceSaborContext()
    {
    }

    public DulceSaborContext(DbContextOptions<DulceSaborContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Combo> Combos { get; set; }

    public virtual DbSet<CombosPlato> CombosPlatos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<Plato> Platos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("CLIENTE");

            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña).HasColumnName("contraseña");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Combo>(entity =>
        {
            entity.HasKey(e => e.ComboId).HasName("PK__COMBOS__18F74AA3E409E772");

            entity.ToTable("COMBOS");

            entity.Property(e => e.ComboId).HasColumnName("combo_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<CombosPlato>(entity =>
        {
            entity.HasKey(e => new { e.ComboId, e.PlatoId }).HasName("PK__COMBOS_P__FA064B59E351DEDD");

            entity.ToTable("COMBOS_PLATOS");

            entity.Property(e => e.ComboId).HasColumnName("combo_id");
            entity.Property(e => e.PlatoId).HasColumnName("plato_id");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("PEDIDO");

            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDO_CLIENTE");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.DetallePedidoId).HasName("PK_DETALLE_PEDIDO");

            entity.ToTable("PEDIDO_DETALLE");

            entity.Property(e => e.DetallePedidoId)
                .ValueGeneratedNever()
                .HasColumnName("detallePedido_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ComboId).HasColumnName("combo_id");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.PlatoId).HasColumnName("plato_id");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("money")
                .HasColumnName("precioUnitario");
            entity.Property(e => e.Subtotal)
                .HasColumnType("money")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDO_DETALLE_PEDIDO");
        });

        modelBuilder.Entity<Plato>(entity =>
        {
            entity.HasKey(e => e.PlatoId).HasName("PK__platos__2F101FAF7E38F72C");

            entity.ToTable("PLATOS");

            entity.Property(e => e.PlatoId).HasColumnName("plato_id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
