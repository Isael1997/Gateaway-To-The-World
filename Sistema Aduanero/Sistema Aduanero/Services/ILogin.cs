using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public interface ILogin
    {
        Usuario Iniciar_Sesion(string correo, string pass);

        string Nombre_Del_Rol(Usuario datos_del_usuario);

    }
}
