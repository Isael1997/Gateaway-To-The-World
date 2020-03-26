using System;
using System.Collections.Generic;


namespace Sistema_Aduanero.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            ClientesCorreo = new HashSet<ClientesCorreo>();
            Declaracion = new HashSet<Declaracion>();
            Entrega = new HashSet<Entrega>();
            Envio = new HashSet<Envio>();
            Facturacion = new HashSet<Facturacion>();
            Pedidos = new HashSet<Pedidos>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Empresa { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string Calle { get; set; }
        public string Sector { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Estatus { get; set; }

        public ICollection<ClientesCorreo> ClientesCorreo { get; set; }
        public ICollection<Declaracion> Declaracion { get; set; }
        public ICollection<Entrega> Entrega { get; set; }
        public ICollection<Envio> Envio { get; set; }
        public ICollection<Facturacion> Facturacion { get; set; }
        public ICollection<Pedidos> Pedidos { get; set; }
    }
}
