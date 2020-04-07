using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Services
{
    public interface ICRUD_Usuario
    {
        //...
        Usuario Perfil_Usuario(int id);
        Usuario Agregar_Usuario(Usuario datos_del_usuario, string correo_del_usuario, string telefono_del_usuario);
        Usuario Editar_Perfil_Usuario(int id);
        List<Usuario> Listado_Cliente();
    }
}
