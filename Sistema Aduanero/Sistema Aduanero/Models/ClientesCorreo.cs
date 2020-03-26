using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class ClientesCorreo
    {
        public int CodigoCorreo { get; set; }
        public string Correo { get; set; }
        public int? ClienteIdFk { get; set; }

        public Clientes ClienteIdFkNavigation { get; set; }
    }
}
