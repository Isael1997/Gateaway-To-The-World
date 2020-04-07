using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Services
{
    public interface IDeclarar
    {
        Solicitud Declarar_Solicitud(int id_solicitud);
    }
}
