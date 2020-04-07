using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class Declarar : IDeclarar
    {
        private Solicitud _solicitud;
        public Solicitud Declarar_Solicitud(int id_cliente)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                //...
            }
            return _solicitud;
        }
    }
}
