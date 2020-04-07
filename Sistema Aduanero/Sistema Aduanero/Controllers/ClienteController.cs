using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Controllers;
using Sistema_Aduanero.Services;
using Sistema_Aduanero.Calculo_De_Costo;

namespace Sistema_Aduanero.Controllers
{
    public class ClienteController : Controller
    {
        private ILogin _login;
        private ICRUD_Usuario _crud_Usuario;
        private ICRUD_Telefono_y_Correo _crud_Telefono_y_Correo;
        private IValidacion_Solicitud_De_Servicio _validacion_Solicitud_De_Servicio;
        private ICRUD_Solicitud_De_Servicios _crud_Solicitud_De_Servicios;

        //private string _rol_del_usuario;
        public ClienteController(ILogin login, ICRUD_Usuario crud_Usuario, ICRUD_Telefono_y_Correo crud_Telefono_y_Correo,
            IValidacion_Solicitud_De_Servicio validacion_Solicitud_De_Servicio, ICRUD_Solicitud_De_Servicios crud_Solicitud_De_Servicios)
        {
            _login = login;
            _crud_Usuario = crud_Usuario;
            _crud_Telefono_y_Correo = crud_Telefono_y_Correo;
            _validacion_Solicitud_De_Servicio = validacion_Solicitud_De_Servicio;
            _crud_Solicitud_De_Servicios = crud_Solicitud_De_Servicios;
        }

        //  Este es el perfil del cliente
        public IActionResult Perfil()
        {
            int id_usuario = _id_Del_Usuario();//El id del usuario es obtenido solo si el usuario inicio sesion.

            var model = _crud_Usuario.Perfil_Usuario(id_usuario);
            var model_telefono = _crud_Telefono_y_Correo.Telefono_Usuario(id_usuario);
            var model_correo = _crud_Telefono_y_Correo.Correo_Usuario(id_usuario);

            ViewBag.Perfil = model;
            ViewBag.Telefono_Usuario = model_telefono;
            ViewBag.Correo_Usuario = model_correo;
            return View();
        }

        //  Esta acción la utilizo para cerrar la sesion.
        public IActionResult Cerrar_Sesion() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        //  Esta acción la utilizo para listar los servicios contratados.
        public IActionResult Listado_De_Servicios_Contratados()
        {
            return View();
        }

        //   Esta acción la utilizo para facturar los servicios contratados.
        [HttpGet]
        public IActionResult Facturar()
        {
            return View();
        }

        //  Esta acción la utilizo para facturar los servicios contratados.
        [HttpPost]
        public IActionResult Facturar(string no_solicitud, string balance)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Solicitar_Servicio_De_Importacion_O_Exportacion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solicitar_Servicio_De_Importacion_O_Exportacion(string tiempo_de_llegada, string servicios, string tipos_de_articulos,
            int cantidad, string peso_de_la_mercancia, string descripcion, string nombre_receptor, string cedula_receptor)
        {
            int id_cliente = _id_Del_Usuario(); //  El id del usuario.

            //Validando los datos enviados por el formulario.
            var model = _validacion_Solicitud_De_Servicio.Validar_Datos_A_Guardar(tiempo_de_llegada, servicios, tipos_de_articulos, cantidad,
                peso_de_la_mercancia, descripcion, nombre_receptor, cedula_receptor);
            var validando_el_peso_de_la_mercancia = new Calculo_De_Peso();
            var validando_el_tipo_de_articulo = new Tipo_De_Mercancia();
            
            if (model != null && validando_el_peso_de_la_mercancia.Conversion_Del_Peso(peso_de_la_mercancia) > 0 &&
                validando_el_tipo_de_articulo.Validando_Tipo_De_Mercancia_o_Articulo(tipos_de_articulos) != null)
            {
                _crud_Solicitud_De_Servicios.Nueva_Solicitud(model, id_cliente);
                return RedirectToAction(nameof(Listado_De_Servicios_Contratados));
            }
            return View();
        }

        //  Este metodo nos devuelve la seccion que contiene como valor el id del usuario.
        private int _id_Del_Usuario()
        {
            //  Se captura id del usuario (OJO este debe ser convertido a int) esto siempre y cuando se quieran hacer
            //  consultas a base de datos.
            return int.Parse(HttpContext.Session.GetString("perfil"));
        }
    }
}