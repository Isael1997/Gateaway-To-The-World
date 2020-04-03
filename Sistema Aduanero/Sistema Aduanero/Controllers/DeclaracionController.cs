using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Controllers
{
    public class DeclaracionController : Controller
    {

        private DataBAse db = new DataBAse();

        public IActionResult Index()
        {
            var declaracion = db.Declaracion.ToList();
            
            return View(declaracion);
        }
    }
}