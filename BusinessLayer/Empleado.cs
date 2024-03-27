using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLayer
{
    public class Empleado
    {

        //ML 
        //Propiedades

        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Decimal Sueldo { get; set; }
        public List<Empleado> Empleados { get; set; }

        //Propiedad de Navegacion
        public BusinessLayer.Area Area { get; set; }

        //Constructor
        public Empleado() { }


        //METODOS CAPA DE NEGOCIO BL


        public static Dictionary<string, object> GetAll()
        {
            BusinessLayer.Empleado emp = new BusinessLayer.Empleado();
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Empleado", emp }, { "Exepcion", excepcion }, { "Resultado", false } };

            try
            {
                using (DataLayer.TestSolEntities context = new DataLayer.TestSolEntities())
                {
                    var registros = context.GetAllEmpleado().ToList();

                    if (registros != null)
                    {
                        emp.Empleados = new List<BusinessLayer.Empleado>();

                        foreach (var registro in registros)
                        {
                            //Instanciar el objeto
                            Empleado empleado = new BusinessLayer.Empleado();

                            empleado.IdEmpleado = registro.IdEmpleado;
                            empleado.Nombre = registro.NombreEmpleado;
                            empleado.ApellidoPaterno = registro.ApellidoPaterno;
                            empleado.ApellidoMaterno = registro.ApellidoMaterno;
                            empleado.FechaNacimiento = registro.FechaNacimiento;
                            empleado.Sueldo = registro.Sueldo;

                            //AQUI VA LA PROPIEDAD DE NAVEGACION

                            empleado.Area = new BusinessLayer.Area();
                            empleado.Area.Nombre = registro.NombreArea;


                            emp.Empleados.Add(empleado);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = emp;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> Delete(int IdEmpleado)
        {
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Empleado", IdEmpleado }, { "Excepcion", excepcion }, { "Resultado", false } };
            try
            {

                using (DataLayer.TestSolEntities context = new DataLayer.TestSolEntities())
                {
                    int filasAfectadas = context.DeleteEmpleado(IdEmpleado);

                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {

                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }

            return diccionario;
        }

        public static Dictionary<string, object> Add(BusinessLayer.Empleado empleado)
        {
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", excepcion }, { "Resultado", false } };

            try
            {
                // Abrir Conexion

                using (DataLayer.TestSolEntities context = new DataLayer.TestSolEntities())
                {

                    int filasAfectadas = context.AddEmpleado(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.FechaNacimiento, empleado.Sueldo, empleado.Area.IdArea);

                    //Validar si las filas fueron afectadas
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex) //SI FALLÓ ALGO
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;

            }
            return diccionario;
        }


        public static Dictionary<string, object> Update(BusinessLayer.Empleado empleado)
        {
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", empleado }, { "Excepcion", excepcion }, { "Resultado", false } };

            try
            {
                using (DataLayer.TestSolEntities context = new DataLayer.TestSolEntities())
                {

                    int filasAfectadas = context.UpdateEmpleado(empleado.IdEmpleado, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.FechaNacimiento, empleado.Sueldo, empleado.Area.IdArea);

                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }

            }
            catch (Exception ex)
            {

                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }

            return diccionario;
        }


    }
}
