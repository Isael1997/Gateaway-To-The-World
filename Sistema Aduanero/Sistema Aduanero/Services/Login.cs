using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class Login : ILogin
    {
        private UsuarioCorreo _usuarioCorreo;
        private Usuario _datos_del_usuario;
        private RoleUsuario _roleUsuario;
        public Login()
        {
            _datos_del_usuario = new Usuario();
            _usuarioCorreo = new UsuarioCorreo();
            _roleUsuario = new RoleUsuario();
        }

        public Usuario Iniciar_Sesion(string correo, string pass)
        {
            //Primero se procede a validar que los datos no sean nulos.
            if (correo != null && pass != null)
            {
                using (DB_A5759C_gatewaytotheworldContext dbcontext = new DB_A5759C_gatewaytotheworldContext())
                {
                    _usuarioCorreo = dbcontext.UsuarioCorreo.Where(u => u.Correo == correo).FirstOrDefault();
                    //Se procede a obtener los datos del usuario.
                    _datos_del_usuario = dbcontext.Usuario.Find(_usuarioCorreo.IdUsuarioFkCorreo);
                }
            }
            return _datos_del_usuario;
        }

        public string Nombre_Del_Rol(Usuario datos_del_usuario)
        {
            string rol_del_usuario;
            using(DB_A5759C_gatewaytotheworldContext dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var model = dbcontext.RoleUsuario.Find(datos_del_usuario.IdRolFk);
                rol_del_usuario = model.TipoDeRol;
            }
            return rol_del_usuario;
        }
    }
}
