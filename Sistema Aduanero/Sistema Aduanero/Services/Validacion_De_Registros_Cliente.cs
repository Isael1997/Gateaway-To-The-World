using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class Validacion_De_Registros_Cliente : IValidacion_De_Registros_Cliente
    {
        private Usuario _obj_datos_usuario;

        public Validacion_De_Registros_Cliente()
        {
            _obj_datos_usuario = new Usuario();
        }
        public string Correo_Usuario(string correo)
        {
            string correo_valido = (correo != null) ? correo : null;
            return correo_valido;
        }

        public Usuario Datos_Del_Cliente(string apellidos, string nombres, string cedula, string telefono, string empresa, string correo, 
                                                            string pass, string provincia, string municipio, string calle, string sector)
        {
            if (apellidos != null && nombres != null && cedula != null &&
                Telefono_Usuario(telefono) != null && Correo_Usuario(correo) != null &&
                pass != null && provincia != null && municipio != null && calle != null &&
                sector != null)
            {
                _obj_datos_usuario.Apellidos = apellidos;
                _obj_datos_usuario.Nombres = nombres;
                _obj_datos_usuario.Cedula = cedula;
                _obj_datos_usuario.Empresa = empresa;
                _obj_datos_usuario.Pass = pass;
                _obj_datos_usuario.Provincia = provincia;
                _obj_datos_usuario.Municipio = municipio;
                _obj_datos_usuario.Calle = calle;
                _obj_datos_usuario.Sector = sector;

                //  Retornamos los datos del usuario como un objeto para su facil registro o utilizacion de los mismos una
                //  vez hayan sido validados.
                return _obj_datos_usuario;
            }
            return _obj_datos_usuario;
        }

        public string Telefono_Usuario(string telefono)
        {
            string telefono_validado = (telefono != null && telefono.Length == 10) ? telefono : null;
            return telefono_validado;
        }
    }
}
