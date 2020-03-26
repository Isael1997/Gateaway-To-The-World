using System;
using System.Collections.Generic;


namespace Sistema_Aduanero.Models
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            Facturacion = new HashSet<Facturacion>();
        }

        public int NoPedido { get; set; }
        public string TipoPedido { get; set; }
        public string TipoMercancia { get; set; }
        public int? Cantidad { get; set; }
        public double? Peso { get; set; }
        public string Descripción { get; set; }
        public string Estatus { get; set; }
        public int ClienteIdFk { get; set; }

        public Clientes ClienteIdFkNavigation { get; set; }
        public ICollection<Facturacion> Facturacion { get; set; }
    }
}
