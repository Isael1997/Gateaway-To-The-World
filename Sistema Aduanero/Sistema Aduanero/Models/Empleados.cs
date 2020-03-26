using System;
using System.Collections.Generic;


namespace Sistema_Aduanero.Models
{
    public partial class Empleados
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Cargo { get; set; }
        public string Estatus { get; set; }
    }
}
