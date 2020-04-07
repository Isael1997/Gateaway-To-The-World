using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Aduanero.Models;
namespace Sistema_Aduanero.Services
{
    public interface IHacer_Estrega
    {
        void Guardar_Entrega(Facturacion facturacion);
        Facturacion Buscar_Factura_Por_IdServicioContratado(int id_solicitud);
        //Entrega Datos_De_La_Entrega(Facturacion facturacion);
    }
}
