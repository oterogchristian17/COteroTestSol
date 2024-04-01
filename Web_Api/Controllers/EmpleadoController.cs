using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class EmpleadoController : ApiController
    {

        [HttpPost]
        [Route("api/Empleado/Add")]
        public IHttpActionResult Add([FromBody] BusinessLayer.Empleado empleado)
        {
            Dictionary<string, object> resultado = BusinessLayer.Empleado.Add(empleado);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest((string)resultado["Resultado"]);
            }
        }

        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            BusinessLayer.Empleado empleado = new BusinessLayer.Empleado();
            Dictionary<string, object> resultado = BusinessLayer.Empleado.GetAll();
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                empleado = (BusinessLayer.Empleado)resultado["Empleado"];
                return Content(HttpStatusCode.OK, empleado);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete]
        [Route("api/Empleado/Delete/{IdEmpleado}")]
        public IHttpActionResult Delete(int IdEmpleado)
        {
            Dictionary<string, object> resultado = BusinessLayer.Empleado.Delete(IdEmpleado);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest((string)resultado["Resultado"]);
            }
        }


        [HttpPut]
        [Route("api/Empleado/Update/{IdEmpleado}")]
        public IHttpActionResult Update([FromBody] BusinessLayer.Empleado empleado)
        {
            Dictionary<string, object> resultado = BusinessLayer.Empleado.Update(empleado);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest((string)resultado["Resultado"]);
            }
        }



    }
}
