using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Controllers
{
    public class EmpleadoController : Controller
    {
        public EmpleadoController()
        {
            //...
        }
        public IActionResult Perfil()
        {
            return View();
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
            return View();
        }
        public IActionResult Hacer_Entrega()
        {
            return View();
        }
    }
}