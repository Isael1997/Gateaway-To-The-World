using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Services
{
    public interface IValidacion_De_Registros_Cliente
    {
        Usuario Datos_Del_Cliente(string apellidos, string nombres, string cedula, string telefono, string empresa, string correo,
                                                    string pass, string provincia, string municipio, string calle, string sector);

        string Telefono_Usuario(string telefono);

        string Correo_Usuario(string correo);
    }
}
