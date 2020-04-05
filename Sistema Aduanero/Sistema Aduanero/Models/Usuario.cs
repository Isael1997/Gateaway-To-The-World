using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Declaracion = new HashSet<Declaracion>();
            Entrega = new HashSet<Entrega>();
            Envio = new HashSet<Envio>();
            Facturacion = new HashSet<Facturacion>();
            Solicitud = new HashSet<Solicitud>();
            UsuarioCorreo = new HashSet<UsuarioCorreo>();
            UsuarioTelefono = new HashSet<UsuarioTelefono>();
        }

        public int Id { get; set; }
        public int? IdRolFk { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Pass { get; set; }
        public string Empresa { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string Calle { get; set; }
        public string Sector { get; set; }
        public string Estatus { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaDeRegistro { get; set; }

        public RoleUsuario IdRolFkNavigation { get; set; }
        public ICollection<Declaracion> Declaracion { get; set; }
        public ICollection<Entrega> Entrega { get; set; }
        public ICollection<Envio> Envio { get; set; }
        public ICollection<Facturacion> Facturacion { get; set; }
        public ICollection<Solicitud> Solicitud { get; set; }
        public ICollection<UsuarioCorreo> UsuarioCorreo { get; set; }
        public ICollection<UsuarioTelefono> UsuarioTelefono { get; set; }
    }
}
