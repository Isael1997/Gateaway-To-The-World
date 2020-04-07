using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public interface ICRUD_Telefono_y_Correo
    {
        Usuario Perfil(int id);
        Usuario Perfil(Usuario datos_del_usuario, string telefono, string correo);
        UsuarioTelefono Telefono_Usuario(int id_usuario);
        UsuarioCorreo Correo_Usuario(int id_usuario);
        void Agregar_Telefono_Usuario(int id_cliente_fk, string telefono);
        void Agregar_Correo_Usuario(int id_cliente_fk,string correo);
    }
}
