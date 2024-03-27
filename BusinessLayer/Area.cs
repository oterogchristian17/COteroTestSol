using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Area
    {

        //ML 
        //Propiedades

        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public List<Area> Areas { get; set; }



        //METODOS CAPA DE NEGOCIO BL

        public static Dictionary<string, object> GetAll()
        {
            BusinessLayer.Area area = new BusinessLayer.Area();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Area", area }, { "Excepcion", null }, { "Resultado", false } };
            try
            {
                using (DataLayer.TestSolEntities context = new DataLayer.TestSolEntities())
                {
                    var objeto = context.GetAllArea().ToList();

                    if (objeto != null)
                    {
                        area.Areas = new List<BusinessLayer.Area>();
                        foreach (var objarea in objeto)
                        {
                            BusinessLayer.Area areaobj = new BusinessLayer.Area();
                            areaobj.IdArea = objarea.IdArea;
                            areaobj.Nombre = objarea.Nombre;

                            area.Areas.Add(areaobj);
                        }
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
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }
    }

}

