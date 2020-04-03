using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Controllers
{
    public class EntregaController : Controller
    {
        private DataBAse db = new DataBAse();

        public IActionResult Index()
        {
            var entrega = db.Entrega.ToList();

            return View(entrega);
        }
    }
}