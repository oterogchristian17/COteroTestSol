using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterfaz.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult EmpleadoGetAll(BusinessLayer.Empleado empleado)
        {
            Dictionary<string, object> resultado = BusinessLayer.Empleado.GetAll();
            bool correct = (bool)resultado["Resultado"];
            if (correct)
            {
                empleado = (BusinessLayer.Empleado)resultado["Empleado"];
                return View(empleado);
            }

            return View();

        }

        [HttpGet]
        public ActionResult Delete(int EmpleadoID)
        {
            Dictionary<string, object> result = BusinessLayer.Empleado.Delete(EmpleadoID);
            bool resultado = (bool)result["Resultado"];

            if (resultado == true)
            {

                ViewBag.Mensaje = "El Empleado ha sido eliminado";
                return PartialView("Modal");

            }
            else
            {
                //pendiente una alerta para la excepcion
                string excepcion = (string)result["Excepcion"];
                ViewBag.Mensaje = "El Empleado no se ha podido eliminar";
                return PartialView("Modal");

            }
        }

        [HttpGet]
        public ActionResult Formulario()
        {
            BusinessLayer.Empleado empleado = new BusinessLayer.Empleado();
            return View(empleado);
        }


        [HttpPost]
        public ActionResult Formulario(BusinessLayer.Empleado empleado)
        {

            if (empleado.IdEmpleado > 0)
            {

                Dictionary<string, object> resultado = BusinessLayer.Empleado.Update(empleado);

                bool result = (bool)resultado["Resultado"];

                if (result == true)
                {
                    ViewBag.Mensaje = "El Hospital ha sido actualizado";
                    return PartialView("Modal");
                }
                else
                {
                    string excepcion = (string)resultado["Excepcion"];
                    ViewBag.Mensaje = "El Hospital no se pudo actualizar" + excepcion;
                    return PartialView("Modal");
                }
                return View(empleado);
            }
            else
            {
                Dictionary<string, object> resultado = BusinessLayer.Empleado.Add(empleado);

                bool result = (bool)resultado["Resultado"];
                if (result)
                {
                    ViewBag.Mensaje = "El Empleado ha sido agregado";
                    return PartialView("Modal");
                }
                else
                {
                    string exepcion = (string)resultado["Excepcion"];
                    ViewBag.Mensaje = "El Empleado no se pudo agregar" + exepcion;
                    return PartialView("Modal");
                }


                return View(empleado);

            }
        }




    }
}