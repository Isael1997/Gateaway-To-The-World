using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sistema_Aduanero.Models
{
    public partial class DB_A5759C_gatewaytotheworldContext : DbContext
    {
        public DB_A5759C_gatewaytotheworldContext()
        {
        }

        public DB_A5759C_gatewaytotheworldContext(DbContextOptions<DB_A5759C_gatewaytotheworldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Declaracion> Declaracion { get; set; }
        public virtual DbSet<Entrega> Entrega { get; set; }
        public virtual DbSet<Envio> Envio { get; set; }
        public virtual DbSet<Facturacion> Facturacion { get; set; }
        public virtual DbSet<RoleUsuario> RoleUsuario { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioCorreo> UsuarioCorreo { get; set; }
        public virtual DbSet<UsuarioTelefono> UsuarioTelefono { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SQL5033.site4now.net;Initial Catalog=DB_A5759C_gatewaytotheworld;User Id=DB_A5759C_gatewaytotheworld_admin;Password=mkgchalona123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Declaracion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("text");

                entity.Property(e => e.Estatus)
                    .HasColumnName("estatus")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdClienteFkDeclaracion).HasColumnName("id_cliente_fk_declaracion");

                entity.Property(e => e.IdFacturaFkDeclaracion).HasColumnName("id_factura_fk_declaracion");

                entity.HasOne(d => d.IdClienteFkDeclaracionNavigation)
                    .WithMany(p => p.Declaracion)
                    .HasForeignKey(d => d.IdClienteFkDeclaracion)
                    .HasConstraintName("FK_CD");

                entity.HasOne(d => d.IdFacturaFkDeclaracionNavigation)
                    .WithMany(p => p.Declaracion)
                    .HasForeignKey(d => d.IdFacturaFkDeclaracion)
                    .HasConstraintName("FK_FD");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasKey(e => e.IdEntrega);

                entity.Property(e => e.IdEntrega).HasColumnName("ID_Entrega");

                entity.Property(e => e.CantidadArticulos).HasColumnName("cantidad_articulos");

                entity.Property(e => e.CedulaQuienRecibe)
                    .HasColumnName("cedula_quien_recibe")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeEntrega)
                    .HasColumnName("fecha_de_entrega")
                    .HasColumnType("date");

                entity.Property(e => e.IdClienteFkEntrega).HasColumnName("id_cliente_fk_entrega");

                entity.Property(e => e.IdFacturaFkEntrega).HasColumnName("id_factura_fk_entrega");

                entity.HasOne(d => d.IdClienteFkEntregaNavigation)
                    .WithMany(p => p.Entrega)
                    .HasForeignKey(d => d.IdClienteFkEntrega)
                    .HasConstraintName("FK_CE");

                entity.HasOne(d => d.IdFacturaFkEntregaNavigation)
                    .WithMany(p => p.Entrega)
                    .HasForeignKey(d => d.IdFacturaFkEntrega)
                    .HasConstraintName("FK_FE");
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.HasKey(e => e.IdEnvio);

                entity.Property(e => e.IdEnvio).HasColumnName("ID_Envio");

                entity.Property(e => e.CantidadArticulos).HasColumnName("cantidad_articulos");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeEnvio)
                    .HasColumnName("fecha_de_envio")
                    .HasColumnType("date");

                entity.Property(e => e.IdClienteFkEnvio).HasColumnName("id_cliente_fk_envio");

                entity.Property(e => e.IdFacturaFkEnvio).HasColumnName("id_factura_fk_envio");

                entity.HasOne(d => d.IdClienteFkEnvioNavigation)
                    .WithMany(p => p.Envio)
                    .HasForeignKey(d => d.IdClienteFkEnvio)
                    .HasConstraintName("FK_CE1");

                entity.HasOne(d => d.IdFacturaFkEnvioNavigation)
                    .WithMany(p => p.Envio)
                    .HasForeignKey(d => d.IdFacturaFkEnvio)
                    .HasConstraintName("FK_FE1");
            });

            modelBuilder.Entity<Facturacion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.FechaDeFacturacion)
                    .HasColumnName("fecha_de_facturacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdClienteFkFacturacion).HasColumnName("id_cliente_fk_facturacion");

                entity.Property(e => e.IdSolicitudFkFacturacion).HasColumnName("id_solicitud_fk_facturacion");

                entity.Property(e => e.TipoPago)
                    .HasColumnName("Tipo_Pago")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteFkFacturacionNavigation)
                    .WithMany(p => p.Facturacion)
                    .HasForeignKey(d => d.IdClienteFkFacturacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CF");

                entity.HasOne(d => d.IdSolicitudFkFacturacionNavigation)
                    .WithMany(p => p.Facturacion)
                    .HasForeignKey(d => d.IdSolicitudFkFacturacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PF");
            });

            modelBuilder.Entity<RoleUsuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TipoDeRol)
                    .HasColumnName("tipo_de_rol")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Descripción)
                    .HasColumnName("descripción")
                    .HasColumnType("text");

                entity.Property(e => e.Estatus)
                    .HasColumnName("estatus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeLaSolicitud)
                    .HasColumnName("fecha_de_la_solicitud")
                    .HasColumnType("date");

                entity.Property(e => e.IdClienteFkSolicitud).HasColumnName("id_cliente_fk_solicitud");

                entity.Property(e => e.NombreCompletoDeQuienRecibe)
                    .HasColumnName("nombre_completo_de_quien_recibe")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.PesoDeLaMercancia)
                    .HasColumnName("peso_de_la_mercancia")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoDeseadoEnLlegar)
                    .HasColumnName("tiempo_deseado_en_llegar")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeSolicitud)
                    .HasColumnName("tipo_de_solicitud")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TipoMercancia)
                    .HasColumnName("tipo_Mercancia")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdClienteFkSolicitudNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdClienteFkSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CP");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Calle)
                    .HasColumnName("calle")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasColumnName("empresa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasColumnName("estatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeRegistro)
                    .HasColumnName("fecha_de_registro")
                    .HasColumnType("date");

                entity.Property(e => e.IdRolFk).HasColumnName("id_rol_fk");

                entity.Property(e => e.Municipio)
                    .HasColumnName("municipio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasColumnName("sector")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolFkNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRolFk)
                    .HasConstraintName("id_rol_fk");
            });

            modelBuilder.Entity<UsuarioCorreo>(entity =>
            {
                entity.ToTable("Usuario_Correo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuarioFkCorreo).HasColumnName("id_usuario_fk_correo");

                entity.HasOne(d => d.IdUsuarioFkCorreoNavigation)
                    .WithMany(p => p.UsuarioCorreo)
                    .HasForeignKey(d => d.IdUsuarioFkCorreo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_usuario_fk_correo");
            });

            modelBuilder.Entity<UsuarioTelefono>(entity =>
            {
                entity.ToTable("Usuario_Telefono");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdUsuarioFkTelefono).HasColumnName("id_usuario_fk_telefono");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioFkTelefonoNavigation)
                    .WithMany(p => p.UsuarioTelefono)
                    .HasForeignKey(d => d.IdUsuarioFkTelefono)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT");
            });
        }
    }
}
