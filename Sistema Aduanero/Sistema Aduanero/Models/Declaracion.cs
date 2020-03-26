using System;
using System.Collections.Generic;


namespace Sistema_Aduanero.Models
{
    public partial class Declaracion
    {
        public int NoDeclaracion { get; set; }
        public int? IdFacturaFk { get; set; }
        public int? ClienteIdFk { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }

        public Clientes ClienteIdFkNavigation { get; set; }
        public Facturacion IdFacturaFkNavigation { get; set; }
    }
}
