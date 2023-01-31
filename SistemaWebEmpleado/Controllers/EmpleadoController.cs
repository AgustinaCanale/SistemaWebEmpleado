using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly DBWebEmpleadoContext context;

        public EmpleadoController(DBWebEmpleadoContext context)
        {
            this.context = context;

        }


    


        [HttpGet]
        public IActionResult Index()
        {
            var empleados = context.Empleados.ToList();
            return View("Index", empleados);
        }



        //Create

        [HttpGet]
        public ActionResult Create()
        {

            Empleado empleado = new Empleado();

            return View("Create", empleado);

        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }


        ////GET Empleado/PorTitulo/titulo
        //[HttpGet]
        //public ActionResult DetailsTitulo(string Titulo)
        //{
        //    Empleado empleado = context.Empleados.Find(Titulo);
        //    if (empleado == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return View("DetailsTitulo", empleado);
        //    }

        //}


        [HttpGet]
        public ActionResult Detalle(int id)
        {
            Empleado empleado = context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Detalle", empleado);
            }
        }


            //Delete

            [HttpGet]


        public ActionResult Delete(int id)
        {
            var empleado = context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }

            else
            {
                return View(empleado);
            }

        }


        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var empleado = context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }


        //Edit

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empleado = context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpPost]
        [ActionName("Edit")]

        public ActionResult EditConfirmed(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Entry(empleado).State = EntityState.Modified;

                context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                return View(empleado);
            }
        }

    }
}
