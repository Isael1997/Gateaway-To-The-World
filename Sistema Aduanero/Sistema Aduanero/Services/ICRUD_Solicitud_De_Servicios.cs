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
        Solicitud Mostrar_Solicitud_Por_Factura(int id_solicitud_fk);
        List<Solicitud> Mostrar_Solicitudes();
        List<Solicitud> Mostrar_Solicitudes(int id_usuario);
        List<Solicitud> Mostrar_Solicitudes_Facturado();
        //List<Solicitud> Mostrar_Solicitudes_En_Proceso(int id_usuario);
        //List<Solicitud> Mostrar_Solicitudes_Entregados(int id_usuario);
        void Eliminar_Solicitud(int id_solicitud);
    }
}
