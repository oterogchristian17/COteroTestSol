using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UserInterfaz.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult EmpleadoGetAll(BusinessLayer.Empleado empleado)
        {
            bool resultado = false;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"].ToString());
                var responseTask = client.GetAsync($"Empleado/GetAll");
                responseTask.Wait(); // Llamada al metodo de la api
                List<object> usuarios = new List<object>();
                var respuesta = responseTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                    readTask.Wait();
                    if (readTask.Result.TryGetValue("Empleados", out object usuarioObject) && usuarioObject != null)
                    {
                        usuarios = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(usuarioObject.ToString());
                    }

                    empleado.Empleados = new List<BusinessLayer.Empleado>();
                    foreach (var jsonEmpleado in usuarios)
                    {
                        BusinessLayer.Empleado empleadoDes = Newtonsoft.Json.JsonConvert.DeserializeObject<BusinessLayer.Empleado>(jsonEmpleado.ToString());
                        empleado.Empleados.Add(empleadoDes);
                    }
                }
                else
                {
                    //resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseTask.Result["Mensaje"]);
                }

            }

            Dictionary<string, object> result = BusinessLayer.Empleado.GetAll();

            if (empleado.Empleados != null)
            {

                // usuario = (ML.Usuario)result["Usuario"];
                return View(empleado);

            }
            else
            {
                //pendiente una alerta para la excepcion
                // string excepcion = (string)result["Excepcion"];
                return View();

            }


            //Dictionary<string, object> resultado = BusinessLayer.Empleado.GetAll();
            //bool correct = (bool)resultado["Resultado"];
            //if (correct)
            //{
            //    empleado = (BusinessLayer.Empleado)resultado["Empleado"];
            //    return View(empleado);
            //}

            //return View();

        }

        [HttpGet]
        public ActionResult Delete(int IdEmpleado)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"].ToString());
                var responseTask = client.DeleteAsync($"Empleado/Delete/{IdEmpleado}");
                responseTask.Wait();
                var respuesta = responseTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                    readTask.Wait();
                    result = readTask.Result;

                }
                else
                {
                    var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                    readTask.Wait();
                    result = readTask.Result;
                }
            }
            ViewBag.Mensaje = "El Empleado ha sido eliminado";
            return PartialView("Modal");
        }

        //    bool resultado = (bool)result["Resultado"];

        //    if (resultado == true)
        //    {

        //        ViewBag.Mensaje = "El Empleado ha sido eliminado";
        //        return PartialView("Modal");

        //    }
        //    else
        //    {
        //        //pendiente una alerta para la excepcion
        //        string excepcion = (string)result["Excepcion"];
        //        ViewBag.Mensaje = "El Empleado no se ha podido eliminar";
        //        return PartialView("Modal");

        //    }
        //}

        [HttpGet]
        public ActionResult Formulario(int? IdEmpleado)
        {
            BusinessLayer.Empleado empleado = new BusinessLayer.Empleado();

            if (IdEmpleado != null)
            {


            }
            else
            {
                empleado.Area = new BusinessLayer.Area();
            }

            Dictionary<string, object> resultArea = BusinessLayer.Area.GetAll();
            bool rolCorrect = (bool)resultArea["Resultado"];

            if (rolCorrect == true)
            {

                BusinessLayer.Area area = (BusinessLayer.Area)resultArea["Area"];
                empleado.Area = new BusinessLayer.Area();
                empleado.Area.Areas = area.Areas;

                return View(empleado);

            }
            else
            {
                string excepcion = (string)resultArea["Excepcion"];
                ViewBag.Mensaje = "Ocurrio un error al recuperar la informacion" + excepcion;
                return View(empleado);

            }
        }


        [HttpPost]
        public ActionResult Formulario(BusinessLayer.Empleado empleado)
        {
            if (ModelState.IsValid)
            {

                if (empleado.IdEmpleado > 0)
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    using (HttpClient client = new HttpClient())
                    {

                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"].ToString());

                        var responseTask = client.PutAsJsonAsync("Empleado/Update/{IdEmpleado}", empleado);
                        responseTask.Wait();
                        var respuesta = responseTask.Result;
                        if (respuesta.IsSuccessStatusCode)
                        {
                            var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                            readTask.Wait();
                            result = readTask.Result;
                        }
                        else
                        {
                            var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                            readTask.Wait();
                            result = readTask.Result;
                        }
                    }
                    bool resultado = (bool)result["Resultado"];

                    if (resultado == true)
                    {
                        ViewBag.Mensaje = "El Empleado ha sido actualizado";
                        return PartialView("Modal");
                    }
                    else
                    {
                        string excepcion = (string)result["Excepcion"];
                        ViewBag.Mensaje = "El Empleado no se pudo actualizar" + excepcion;
                        return PartialView("Modal");
                    }
                }
                else
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();

                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"].ToString());
                        var responseTask = client.PostAsJsonAsync("Empleado/Add", empleado);
                        responseTask.Wait(); // Llamada al metodo de la api
                        var respuesta = responseTask.Result;
                        if (respuesta.IsSuccessStatusCode)
                        {
                            var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                            readTask.Wait();
                            result = readTask.Result;

                        }
                        else
                        {
                            var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                            readTask.Wait();
                            result = readTask.Result;

                            //resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseTask.Result["Mensaje"]);
                        }
                    }
                    bool resultado = (bool)result["Resultado"];

                    if (resultado == true)
                    {
                        ViewBag.Mensaje = "El Empleado ha sido registrado";
                        return PartialView("Modal");
                    }
                    else
                    {
                        string excepcion = (string)result["Excepcion"];
                        ViewBag.Mensaje = "El Empleado no se pudo registrar" + excepcion;
                        return PartialView("Modal");
                    }
                }
            }
            else
            {

                Dictionary<string, object> resultRol = BusinessLayer.Area.GetAll();

                BusinessLayer.Area area = (BusinessLayer.Area)resultRol["Area"];
                empleado.Area.Areas = area.Areas;

                return View(empleado);

            }
        }



    }

}
