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

    public virtual DbSet<CategoriasPlato> CategoriasPlatos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Combo> Combos { get; set; }

    public virtual DbSet<Estadopedido> Estadopedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<Plato> Platos { get; set; }

    public virtual DbSet<Promocione> Promociones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PVK9BJ3\\SQLEXPRESS;Database=DulceSabor;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriasPlato>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__CATEGORI__DB875A4FFF90B59F");

            entity.ToTable("CATEGORIAS_PLATOS");

            entity.HasIndex(e => e.Nombre, "UQ__CATEGORI__72AFBCC6D9EFB776").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

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
            entity.HasKey(e => e.ComboId).HasName("PK__COMBOS__18F74AA3A992DB37");

            entity.ToTable("COMBOS");

            entity.Property(e => e.ComboId).HasColumnName("combo_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("precio");

            entity.HasMany(d => d.Platos).WithMany(p => p.Combos)
                .UsingEntity<Dictionary<string, object>>(
                    "CombosPlato",
                    r => r.HasOne<Plato>().WithMany()
                        .HasForeignKey("PlatoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__combos_pl__plato__6A30C649"),
                    l => l.HasOne<Combo>().WithMany()
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__combos_pl__combo__693CA210"),
                    j =>
                    {
                        j.HasKey("ComboId", "PlatoId").HasName("PK__combos_p__FA064B590346EE8E");
                        j.ToTable("combos_platos");
                        j.IndexerProperty<int>("ComboId").HasColumnName("combo_id");
                        j.IndexerProperty<int>("PlatoId").HasColumnName("plato_id");
                    });
        });

        modelBuilder.Entity<Estadopedido>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.ToTable("ESTADOPEDIDO");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
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
            entity.HasKey(e => e.PlatoId).HasName("PK__PLATOS__2F101FAF45F891FA");

            entity.ToTable("PLATOS");

            entity.Property(e => e.PlatoId).HasColumnName("plato_id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.EsBebida).HasColumnName("es_bebida");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Platos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__PLATOS__categori__6B24EA82");
        });

        modelBuilder.Entity<Promocione>(entity =>
        {
            entity.HasKey(e => e.PromocionId).HasName("PK__PROOCION__EFD43212F4520C2A");

            entity.ToTable("PROMOCIONES");

            entity.Property(e => e.PromocionId).HasColumnName("promocion_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Descuento)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasMany(d => d.Platos).WithMany(p => p.Promocions)
                .UsingEntity<Dictionary<string, object>>(
                    "PromocionesPlato",
                    r => r.HasOne<Plato>().WithMany()
                        .HasForeignKey("PlatoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__promocion__plato__6C190EBB"),
                    l => l.HasOne<Promocione>().WithMany()
                        .HasForeignKey("PromocionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__promocion__promo__72C60C4A"),
                    j =>
                    {
                        j.HasKey("PromocionId", "PlatoId").HasName("PK__promocio__0D2533E80AEE9189");
                        j.ToTable("promociones_platos");
                        j.IndexerProperty<int>("PromocionId").HasColumnName("promocion_id");
                        j.IndexerProperty<int>("PlatoId").HasColumnName("plato_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
