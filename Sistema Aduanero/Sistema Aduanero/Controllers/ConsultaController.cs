using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Controllers
{
    public class ConsultaController : Controller
    {
        private DataBAse db = new DataBAse();

        public IActionResult Cempleado()
        {
            return View();
        }

        public IActionResult Ccliente()
        {
            return View();
        }

        public IActionResult ConsultaCliente()
        {
            var cliente = db.Clientes.ToList();

            return View(cliente);
        }

        public IActionResult ConsultaEmpleado()
        {
            var cliente = db.Clientes.ToList();

            return View(cliente);
        }



    }
}