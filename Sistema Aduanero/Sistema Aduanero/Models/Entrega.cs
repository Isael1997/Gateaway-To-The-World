using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class Entrega
    {
        public int IdEntrega { get; set; }
        public int? IdFacturaFkEntrega { get; set; }
        public int? IdClienteFkEntrega { get; set; }
        public int? CantidadArticulos { get; set; }
        public string CedulaQuienRecibe { get; set; }
        public DateTime? FechaDeEntrega { get; set; }
        public string Estatus { get; set; }

        public Usuario IdClienteFkEntregaNavigation { get; set; }
        public Facturacion IdFacturaFkEntregaNavigation { get; set; }
    }
}
