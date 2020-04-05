using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class Facturacion
    {
        public Facturacion()
        {
            Declaracion = new HashSet<Declaracion>();
            Entrega = new HashSet<Entrega>();
            Envio = new HashSet<Envio>();
        }

        public int Id { get; set; }
        public int IdClienteFkFacturacion { get; set; }
        public string TipoPago { get; set; }
        public int IdSolicitudFkFacturacion { get; set; }
        public DateTime? FechaDeFacturacion { get; set; }
        public decimal? Balance { get; set; }

        public Usuario IdClienteFkFacturacionNavigation { get; set; }
        public Solicitud IdSolicitudFkFacturacionNavigation { get; set; }
        public ICollection<Declaracion> Declaracion { get; set; }
        public ICollection<Entrega> Entrega { get; set; }
        public ICollection<Envio> Envio { get; set; }
    }
}
