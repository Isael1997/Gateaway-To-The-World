using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class Declaracion
    {
        public int Id { get; set; }
        public int? IdFacturaFkDeclaracion { get; set; }
        public int? IdClienteFkDeclaracion { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }

        public Usuario IdClienteFkDeclaracionNavigation { get; set; }
        public Facturacion IdFacturaFkDeclaracionNavigation { get; set; }
    }
}
