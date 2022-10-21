using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoConLINQ
{
    public partial class Cliente
    {
        //Metodo para hallar el nombre completo
        public string NombreCompleto()
        {
            return Apellidos + " " + Nombres;
        }
    }
}
