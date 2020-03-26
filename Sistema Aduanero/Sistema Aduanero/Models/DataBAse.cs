using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Sistema_Aduanero.Models
{
    public partial class DataBAse : DbContext
    {
        public DataBAse()
        {
        }

        public DataBAse(DbContextOptions<DataBAse> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ClientesCorreo> ClientesCorreo { get; set; }
        public virtual DbSet<Declaracion> Declaracion { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Entrega> Entrega { get; set; }
        public virtual DbSet<Envio> Envio { get; set; }
        public virtual DbSet<Facturacion> Facturacion { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }

        // Unable to generate entity type for table 'dbo.Clientes_Telefono'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=RONALD;Initial Catalog=Sistema_Aduanero;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Calle)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientesCorreo>(entity =>
            {
                entity.HasKey(e => e.CodigoCorreo);

                entity.ToTable("CLientes_Correo");

                entity.Property(e => e.CodigoCorreo).HasColumnName("Codigo_Correo");

                entity.Property(e => e.ClienteIdFk).HasColumnName("Cliente_ID_FK");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClienteIdFkNavigation)
                    .WithMany(p => p.ClientesCorreo)
                    .HasForeignKey(d => d.ClienteIdFk)
                    .HasConstraintName("FK_CC");
            });

            modelBuilder.Entity<Declaracion>(entity =>
            {
                entity.HasKey(e => e.NoDeclaracion);

                entity.Property(e => e.NoDeclaracion).HasColumnName("No_Declaracion");

                entity.Property(e => e.ClienteIdFk).HasColumnName("Cliente_ID_Fk");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdFacturaFk).HasColumnName("ID_Factura_FK");

                entity.HasOne(d => d.ClienteIdFkNavigation)
                    .WithMany(p => p.Declaracion)
                    .HasForeignKey(d => d.ClienteIdFk)
                    .HasConstraintName("FK_CD");

                entity.HasOne(d => d.IdFacturaFkNavigation)
                    .WithMany(p => p.Declaracion)
                    .HasForeignKey(d => d.IdFacturaFk)
                    .HasConstraintName("FK_FD");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasKey(e => e.IdEntrega);

                entity.Property(e => e.IdEntrega).HasColumnName("ID_Entrega");

                entity.Property(e => e.CantidadArticulos).HasColumnName("Cantidad_Articulos");

                entity.Property(e => e.ClienteIdFk).HasColumnName("Cliente_ID_FK");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdFacturaFk).HasColumnName("ID_Factura_FK");

                entity.HasOne(d => d.ClienteIdFkNavigation)
                    .WithMany(p => p.Entrega)
                    .HasForeignKey(d => d.ClienteIdFk)
                    .HasConstraintName("FK_CE");

                entity.HasOne(d => d.IdFacturaFkNavigation)
                    .WithMany(p => p.Entrega)
                    .HasForeignKey(d => d.IdFacturaFk)
                    .HasConstraintName("FK_FE");
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.HasKey(e => e.IdEnvio);

                entity.Property(e => e.IdEnvio).HasColumnName("ID_Envio");

                entity.Property(e => e.CantidadArticulos).HasColumnName("Cantidad_Articulos");

                entity.Property(e => e.ClienteIdFk).HasColumnName("Cliente_ID_FK");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdFacturaFk).HasColumnName("ID_Factura_FK");

                entity.HasOne(d => d.ClienteIdFkNavigation)
                    .WithMany(p => p.Envio)
                    .HasForeignKey(d => d.ClienteIdFk)
                    .HasConstraintName("FK_CE1");

                entity.HasOne(d => d.IdFacturaFkNavigation)
                    .WithMany(p => p.Envio)
                    .HasForeignKey(d => d.IdFacturaFk)
                    .HasConstraintName("FK_FE1");
            });

            modelBuilder.Entity<Facturacion>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.Property(e => e.IdFactura).HasColumnName("ID_Factura");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.ClienteIdFk).HasColumnName("Cliente_ID_FK");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoPedidoFk).HasColumnName("No_Pedido_FK");

                entity.Property(e => e.TipoPago)
                    .HasColumnName("Tipo_Pago")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClienteIdFkNavigation)
                    .WithMany(p => p.Facturacion)
                    .HasForeignKey(d => d.ClienteIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CF");

                entity.HasOne(d => d.NoPedidoFkNavigation)
                    .WithMany(p => p.Facturacion)
                    .HasForeignKey(d => d.NoPedidoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PF");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.NoPedido);

                entity.Property(e => e.NoPedido).HasColumnName("No_Pedido");

                entity.Property(e => e.ClienteIdFk).HasColumnName("Cliente_ID_FK");

                entity.Property(e => e.Descripción).HasColumnType("text");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipoMercancia)
                    .HasColumnName("TIpo_Mercancia")
                    .HasColumnType("text");

                entity.Property(e => e.TipoPedido)
                    .HasColumnName("Tipo_Pedido")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClienteIdFkNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ClienteIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CP");
            });
        }
    }
}
