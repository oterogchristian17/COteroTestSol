using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Conexion
    {
        public static string ObtenerConecctionString()
        {
            return ConfigurationManager.ConnectionStrings["TestSol"].ToString();
        }
    }
}
