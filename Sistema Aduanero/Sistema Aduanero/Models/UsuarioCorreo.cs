using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class UsuarioCorreo
    {
        public int Id { get; set; }
        public int IdUsuarioFkCorreo { get; set; }
        public string Correo { get; set; }

        public Usuario IdUsuarioFkCorreoNavigation { get; set; }
    }
}
