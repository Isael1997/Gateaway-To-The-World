using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;
namespace Sistema_Aduanero.Controllers
{
    public class FacturacionController : Controller
    {
        private DataBAse db = new DataBAse();

        public IActionResult Index()
        {
            var facturar = db.Facturacion.ToList(); 

            return View(facturar);
        }

        public IActionResult Facturar()
        {
            return View();
        }
    }
}