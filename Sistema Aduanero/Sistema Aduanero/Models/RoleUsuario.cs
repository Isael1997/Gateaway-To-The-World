using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class RoleUsuario
    {
        public RoleUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string TipoDeRol { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
