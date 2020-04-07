using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public interface IEnviar_Mercancia
    {

        Solicitud Validar_Datos(string id_solicitud, string nombre_remitente, string nombre_receptor, string cedula_receptor);

        Envio Realizar_Envio(Solicitud datos_de_la_solicitud);

        Facturacion Validar_Fue_Facturado(int id_solicitud);

        List<Envio> Listado_General_De_Envios();
        List<Envio> Listado_Envio(int id_solicitud);
    }
}
