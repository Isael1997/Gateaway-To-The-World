using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Controllers
{
    public class PedidosController : Controller
    {
        private DataBAse db = new DataBAse();

        public IActionResult Index()
        {
            var pedido = db.Pedidos.ToList();

            return View(pedido);
        }
        public IActionResult Importacion()
        {
            return View();
        }

        public IActionResult Exportacion()
        {
            return View();
        }
    }
}