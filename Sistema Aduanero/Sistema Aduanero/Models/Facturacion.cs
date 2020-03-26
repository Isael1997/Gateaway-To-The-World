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

        public int IdFactura { get; set; }
        public int ClienteIdFk { get; set; }
        public string TipoPago { get; set; }
        public int NoPedidoFk { get; set; }
        public int? Dia { get; set; }
        public int? Mes { get; set; }
        public int? Anio { get; set; }
        public decimal? Balance { get; set; }
        public string Estatus { get; set; }

        public Clientes ClienteIdFkNavigation { get; set; }
        public Pedidos NoPedidoFkNavigation { get; set; }
        public ICollection<Declaracion> Declaracion { get; set; }
        public ICollection<Entrega> Entrega { get; set; }
        public ICollection<Envio> Envio { get; set; }
    }
}
