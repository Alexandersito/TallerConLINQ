using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultas
{
    public partial class Employees
    {
        public string NombreCompleto()
        {
            return FirstName + " " + LastName;
        }

        public string Ubicacion()
        {
            return City + "-" + Region + "-" + Country;
            
        }
    }
}