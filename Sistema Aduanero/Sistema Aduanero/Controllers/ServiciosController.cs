﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Aduanero.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Exportacion()
        {
            return View();
        }

        public IActionResult Importacion()
        {
            return View();
        }

        public IActionResult Prueba()
        {
            return View();
        }



    }
}