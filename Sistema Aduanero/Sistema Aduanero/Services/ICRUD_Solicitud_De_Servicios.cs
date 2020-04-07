using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Services
{
    public interface ICRUD_Solicitud_De_Servicios
    {
        Solicitud Nueva_Solicitud(Solicitud model, int id_cliente);
        List<Solicitud> Mostrar_Solicitudes();
        Solicitud Editar_Solicitud();
        void Eliminar_Solicitud();
    }
}
