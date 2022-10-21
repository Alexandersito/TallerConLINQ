using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultas
{
    public partial class Products
    {
        public string Stock()
        {
            if (UnitsInStock < 10)
            {
                return UnitsInStock + " Stock muy bajo";
            }
            else
            {
                return UnitsInStock + "";
            }
        }
    }
}