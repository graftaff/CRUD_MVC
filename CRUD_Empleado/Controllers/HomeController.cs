using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Empleado.Controllers
{
    
    public class HomeController : Controller
    {
        Empleado empleado = new Empleado();

        // GET: Home
        public ActionResult Index()
        {
            var empleados = empleado.ListarEmpleados();

            return View(empleados);
        }

        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empleado_"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Empleado empleado_)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                result = empleado_.CrearEmpleado();
            }

            if (result)
                return RedirectToAction("Index");
            else
                return View(empleado_);
        }


        public ActionResult Edit(int Id)
        {
            return View(empleado.SeleccionarEmpleado(Id));
        }
        
        [HttpPost]
        public ActionResult Edit(Empleado empleado_)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                result = empleado_.ActualizarEmpleado();
            }

            if (result)
                return RedirectToAction("Index");
            else
                return View(empleado_);
        }


        public ActionResult Delete(int Id)
        {
            bool result = false;

            result = empleado.EliminarEmpleado(Id);

            if (result)
                return RedirectToAction("Index");
            else
                return Content("Error al eliminar usuario!");
        }
    }
}