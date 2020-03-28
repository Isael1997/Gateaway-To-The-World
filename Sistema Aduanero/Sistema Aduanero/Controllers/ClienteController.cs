using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Controllers;

namespace Sistema_Aduanero.Controllers
{
    public class ClienteController : Controller
    {
        public ClienteController()
        {
            //...
        }
        public IActionResult Perfil()
        {
            return View();
        }
        public IActionResult Listado_De_Servicios_Contratados()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Facturar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Facturar(string no_solicitud, string balance)
        {
            return View();
        }

        public IActionResult Solicitar_Servicio_De_Importacion_O_Exportacion()
        {
            return View();
        }
    }
}