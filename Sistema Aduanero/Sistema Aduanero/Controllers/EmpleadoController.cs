using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;
using Sistema_Aduanero.Services;

namespace Sistema_Aduanero.Controllers
{
    public class EmpleadoController : Controller
    {
        private string _rol_del_usuario;
        private ICRUD_Usuario _crud_Usuario;
        private ICRUD_Telefono_y_Correo _crud_Telefono_y_Correo;
        private ICRUD_Solicitud_De_Servicios _crud_Solicitud_De_Servicios;
        private IFacturar_Servicio _facturar_Servicio;

        public EmpleadoController(ICRUD_Usuario crud_Usuario, ICRUD_Telefono_y_Correo crud_Telefono_y_Correo,
            ICRUD_Solicitud_De_Servicios crud_Solicitud_De_Servicios, IFacturar_Servicio facturar_Servicio)
        {
            _crud_Usuario = crud_Usuario;
            _crud_Telefono_y_Correo = crud_Telefono_y_Correo;
            _crud_Solicitud_De_Servicios = crud_Solicitud_De_Servicios;
            _facturar_Servicio = facturar_Servicio;
        }

        //  Este es el perfil del empleado.
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

        public IActionResult Cerrar_Sesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Listado_De_Solicitudes()
        {
            return View();
        }
        public IActionResult Envio()
        {
            return View();
        }
        public IActionResult Declarar()
        {
            var model = _crud_Solicitud_De_Servicios.Mostrar_Solicitudes_Facturado();

            ViewBag.Solicitudes_Facturadas = model;
            return View();
        }
        [HttpGet]
        public IActionResult Declarar(int id_cliente)
        {
            var model = _crud_Solicitud_De_Servicios.Mostrar_Solicitudes_Facturado();

            ViewBag.Solicitudes_Facturadas = model;
            return View();
        }
        public IActionResult Hacer_Entrega()
        {
            return View();
        }

        public IActionResult Listado_Clientes() 
        {
            var model = _crud_Usuario.Listado_Cliente();

            ViewBag.Listado_Cliente = model;
            return View();
        }
        [HttpGet]
        public IActionResult Listado_Clientes(int id_cliente)
        {
            var model = _crud_Usuario.Listado_Cliente();

            ViewBag.Listado_Cliente = model;
            return View();
        }
        private int _id_Del_Usuario()
        {
            //  Se captura id del usuario (OJO este debe ser convertido a int) esto siempre y cuando se quieran hacer
            //  consultas a base de datos.
            return int.Parse(HttpContext.Session.GetString("perfil"));
        }
    }
}