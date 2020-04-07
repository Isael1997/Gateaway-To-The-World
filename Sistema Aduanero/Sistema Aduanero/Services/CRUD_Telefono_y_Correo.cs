using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class CRUD_Telefono_y_Correo : ICRUD_Telefono_y_Correo
    {
        private Usuario _usuario;
        private UsuarioCorreo _usuarioCorreo;
        private UsuarioTelefono _usuarioTelefono;
        public CRUD_Telefono_y_Correo()
        {
            //...
        }
        public Usuario Perfil(int id) 
        {
            return _usuario;
        }
        public Usuario Perfil(Usuario datos_del_usuario, string telefono, string correo)
        {
            //  Este metodo sera ejecutado unicamente cuando sea llamado por el formulario utilizado
            //  para registrarse.
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                // El objetivo de esta consulta es obtener el Id que le fue asignado al usuario al registrarse.
                var _usuario = dbcontext.Usuario.Where(u => u.Cedula == datos_del_usuario.Cedula).FirstOrDefault();

                // Los siguientes dos metodos se encargaran de registrar la informacion del usuario correspondiente
                // a: telefono y correo.
                Agregar_Correo_Usuario(_usuario.Id, correo);
                Agregar_Telefono_Usuario(_usuario.Id, telefono);

                // Se cambian los datos recibidos para agregar a los mismo que tenia, el ID.
                datos_del_usuario = _usuario;

            }
                return datos_del_usuario;
        }

        public void Agregar_Correo_Usuario(int id_cliente_fk, string correo)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                _usuarioCorreo = new UsuarioCorreo();
                _usuarioCorreo.IdUsuarioFkCorreo = id_cliente_fk;
                _usuarioCorreo.Correo = correo;
                dbcontext.UsuarioCorreo.Add(_usuarioCorreo);
                dbcontext.SaveChanges();
            }
        }

        public void Agregar_Telefono_Usuario(int id_cliente_fk, string telefono)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                _usuarioTelefono = new UsuarioTelefono();
                _usuarioTelefono.IdUsuarioFkTelefono = id_cliente_fk;
                _usuarioTelefono.Telefono = telefono;
                dbcontext.UsuarioTelefono.Add(_usuarioTelefono);
                dbcontext.SaveChanges();
            }
        }

        public UsuarioTelefono Telefono_Usuario(int id_usuario)
        {
            _usuarioCorreo = new UsuarioCorreo();
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var model = dbcontext.UsuarioTelefono.Where(u => u.IdUsuarioFkTelefono == id_usuario).FirstOrDefault();
                _usuarioTelefono = model;
            }
            return _usuarioTelefono;
        }

        public UsuarioCorreo Correo_Usuario(int id_usuario)
        {
            _usuarioCorreo = new UsuarioCorreo();
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var model = dbcontext.UsuarioCorreo.Where(u => u.IdUsuarioFkCorreo == id_usuario).FirstOrDefault();
                _usuarioCorreo = model;
            }
            return _usuarioCorreo;
        }
    }
}
