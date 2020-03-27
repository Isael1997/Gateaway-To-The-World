using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sobre_Nosotros()
        {
            //Información relevante a la empresa.
            ViewData["Message"] = "Your application description page.";

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
        
        public IActionResult Registrar_Nuevo_Cliente()
        {
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
