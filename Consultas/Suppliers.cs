using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultas
{
    public partial class Suppliers
    {
        public string Ubiacion()
        {
            return City + "-" + Region + "-" + Country;
        }
    }
}