using System;
using System.Collections.Generic;


namespace Sistema_Aduanero.Models
{
    public partial class Envio
    {
        public int IdEnvio { get; set; }
        public int? IdFacturaFk { get; set; }
        public int? ClienteIdFk { get; set; }
        public int? CantidadArticulos { get; set; }
        public int? Dia { get; set; }
        public int? Mes { get; set; }
        public int? Año { get; set; }
        public string Estatus { get; set; }

        public Clientes ClienteIdFkNavigation { get; set; }
        public Facturacion IdFacturaFkNavigation { get; set; }
    }
}
