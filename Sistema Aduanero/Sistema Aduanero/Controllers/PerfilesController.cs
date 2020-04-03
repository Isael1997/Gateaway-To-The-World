using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Aduanero.Models;


namespace Sistema_Aduanero.Controllers
{
    public class PerfilesController : Controller
    {

        private DataBAse db = new DataBAse();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginEmpleado()
        {
            return View();
        }

        public IActionResult LoginEmpleadoConfirm(string usuario, string contraseña)
        {
            
            var employ = from datos in db.Empleados select datos;

            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(contraseña))
            {
                return RedirectToAction("LoginEmpleado");
            }
            else 
            {
                employ = employ.Where(a => a.Usuario.Equals(usuario));
                employ = employ.Where(a => a.Contraseña.Equals(contraseña));
                return RedirectToAction("PerfilEmploy");

            }
        }

        public IActionResult LoginCliente()
        {
            return View();
        }

        public IActionResult LoginClienteConfirm(string usuario, string contraseña)
        {

            var cliente = from datos in db.Clientes select datos;

            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(contraseña))
            {
                cliente = cliente.Where(a => a.Usuario.Equals(usuario));
                cliente = cliente.Where(a => a.Contraseña.Equals(contraseña));
                return View(cliente);


            }
            else
            {
                return View(db.Clientes.ToList());
            }


        }

        public IActionResult Registro()
        {
            return View();
        }
 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro([Bind("ID,Nombres,Apellidos,Empresa,Provincia,Municipio,Calle,Sector,Usuario,Contraseña,Estatus")] Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(cliente);
        }

        public IActionResult PerfilEmploy()
        {

            return View();
        }

        public IActionResult PerfilCliente(string usuario, string contraseña)
        {
            var cliente = from datos in db.Clientes select datos;

            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(contraseña))
            {
                cliente = cliente.Where(a => a.Usuario.Equals(usuario));
                cliente = cliente.Where(a => a.Contraseña.Equals(contraseña));
                return View(cliente);

                
            }
            else
            {
                return View(db.Clientes.ToList());
            }



        }
     




        
           

    }
}