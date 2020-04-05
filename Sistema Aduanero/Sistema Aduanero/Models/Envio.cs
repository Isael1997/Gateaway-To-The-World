using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class Envio
    {
        public int IdEnvio { get; set; }
        public int? IdFacturaFkEnvio { get; set; }
        public int? IdClienteFkEnvio { get; set; }
        public int? CantidadArticulos { get; set; }
        public DateTime? FechaDeEnvio { get; set; }
        public string Estatus { get; set; }

        public Usuario IdClienteFkEnvioNavigation { get; set; }
        public Facturacion IdFacturaFkEnvioNavigation { get; set; }
    }
}
