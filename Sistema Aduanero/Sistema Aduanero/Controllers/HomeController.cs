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
    public class HomeController : Controller
    {
        private ILogin _login;
        private IValidacion_De_Registros_Cliente _validacion_De_Registros_Cliente;
        private ICRUD_Usuario _usuario;

        public HomeController(ILogin login, IValidacion_De_Registros_Cliente validacion_De_Registros_Cliente, ICRUD_Usuario usuario)
        {
            _login = login;
            _validacion_De_Registros_Cliente = validacion_De_Registros_Cliente;
            _usuario = usuario;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre_Nosotros()
        {
            //Información relevante a la empresa.
            return View();
        }

        public IActionResult Servicios()
        {
            //En este se programaran los servicios del sistema.
            return View();
        }

        public IActionResult Noticias()
        {
            return View();
        }

        public IActionResult Login()
        {
            //Las acciones del login.
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string pass)
        {
            //Primero validamos que los datos del correo y pass no sean nulos. De no serlos
            //este objeto va a capturar los datos del usuario.
            var datos_del_usuario = _login.Iniciar_Sesion(correo, pass);

            //Este es el nombre del rol al que pertenece el usuario.
            string nombre_del_rol = (datos_del_usuario.IdRolFk != null) ? _login.Nombre_Del_Rol(datos_del_usuario) : null;
            if (datos_del_usuario != null && nombre_del_rol != null)
            {
                HttpContext.Session.SetString("perfil", Convert.ToString(datos_del_usuario.Id));
                //La variable nombre del rol contine el nombre del rol del usuario y la misma se encarga de redireccionar al
                //usuario al su perfil.
                return RedirectToAction("Perfil", nombre_del_rol);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Registrar_Nuevo_Cliente(string apellidos, string nombres, string cedula, string telefono, string empresa, string correo,
                string correo_repetido, string pass, string pass_repetido, string provincia, string municipio, string calle, string sector)
        {
            //  Aquí la validación de los datos a registrar.
            var datos_para_tabla_cliente = _validacion_De_Registros_Cliente.Datos_Del_Cliente(apellidos, nombres, cedula, telefono, empresa, correo,
                                                                                                           pass, provincia, municipio, calle, sector);

            var correo_del_usuario = _validacion_De_Registros_Cliente.Correo_Usuario(correo);
            var telefono_del_usuario = _validacion_De_Registros_Cliente.Telefono_Usuario(telefono);
            //  Aquí la validación de los datos a registrar.

            if (datos_para_tabla_cliente != null && correo_del_usuario != null && telefono_del_usuario != null)
            {
                var model = _usuario.Agregar_Usuario(datos_para_tabla_cliente, correo_del_usuario, telefono_del_usuario);
                HttpContext.Session.SetString("perfil", Convert.ToString(model.Id));
                return RedirectToAction("Perfil", "Cliente");
            }
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
