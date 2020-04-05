using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class UsuarioTelefono
    {
        public int Id { get; set; }
        public int IdUsuarioFkTelefono { get; set; }
        public string Telefono { get; set; }

        public Usuario IdUsuarioFkTelefonoNavigation { get; set; }
    }
}
