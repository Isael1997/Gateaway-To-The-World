using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class CRUD_Usuario : ICRUD_Usuario
    {
        private Usuario _usuario;
        private const int _id_designado_para_cliente = 102578; //Esta variable como su nombre lo indica es el código designado para los clientes.
        private string _estado_del_cliente;
        private const int rol_empleado = 102478;
        private const int rol_cliente = 102578;
        public CRUD_Usuario()
        {
            _estado_del_cliente = "activo"; //Como lo indica su nombre es utilizada para definir el estado del cliente.
        }

        public Usuario Perfil_Usuario(int id)
        {
            Usuario datosDelUsuario;
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                datosDelUsuario = dbcontext.Usuario.Find(id);
            }
            return datosDelUsuario;
        }

        public Usuario Agregar_Usuario(Usuario datos_del_usuario, string correo_del_usuario, string telefono_del_usuario)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                _usuario = new Usuario();
                // Capturando los datos en el objeto "_usuario" para despues almacenarlos.
                _usuario.IdRolFk = _id_designado_para_cliente;
                _usuario.Nombres = datos_del_usuario.Nombres;
                _usuario.Apellidos = datos_del_usuario.Apellidos;
                _usuario.Pass = datos_del_usuario.Pass;
                _usuario.Empresa = datos_del_usuario.Empresa;
                _usuario.Provincia = datos_del_usuario.Provincia;
                _usuario.Municipio = datos_del_usuario.Municipio;
                _usuario.Calle = datos_del_usuario.Calle;
                _usuario.Sector = datos_del_usuario.Sector;
                _usuario.Estatus = _estado_del_cliente;
                _usuario.Cedula = datos_del_usuario.Cedula;
                _usuario.FechaDeRegistro = DateTime.Today;

                // Pasamos a guardar los datos de usuario o por lo menos lo que iran a la TABLA Usuario.
                dbcontext.Usuario.Add(_usuario);
                dbcontext.SaveChanges();
            }

            //Pasamos a guardar los datos en las TABLAS: UsuarioCorreo y UsuarioTelefono, con invocar los siguientes metodos:
            var agregar_telefono_y_correo = new CRUD_Telefono_y_Correo();
            datos_del_usuario =  agregar_telefono_y_correo.Perfil(datos_del_usuario, telefono_del_usuario, correo_del_usuario);

            return datos_del_usuario; //Se retorna un objeto que contiene los datos del usuario.
        }

        public Usuario Editar_Perfil_Usuario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listado_Cliente()
        {
            var list = new List<Usuario>();
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var model = dbcontext.Usuario.Where(uCliente => uCliente.IdRolFk == rol_cliente).ToList();
                list = model;
            }
            return list;
        }
    }
}
