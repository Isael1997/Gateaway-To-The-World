using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Controllers
{
    public class EnvioController : Controller
    {
        private DataBAse db = new DataBAse();

        public IActionResult Index()
        {
            var envio = db.Envio.ToList();

            return View(envio);
        }
    }
}