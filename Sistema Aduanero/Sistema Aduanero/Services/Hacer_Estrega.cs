using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class Hacer_Estrega : IHacer_Estrega
    {
        private Facturacion _facturacion;
        private Solicitud _solicitud;
        private Entrega _entrega;
        private const string estatus_solicitud_entregada = "Entregado";
        public Facturacion Buscar_Factura_Por_IdServicioContratado(int id_solicitud)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var model = dbcontext.Facturacion.Where(idS => idS.IdSolicitudFkFacturacion == id_solicitud).FirstOrDefault();
                _facturacion = (model != null) ? model : null;
            }
            return _facturacion;
        }

        public void Guardar_Entrega(Facturacion facturacion)
        {
            CRUD_Solicitud_De_Servicios crud_Solicitud = new CRUD_Solicitud_De_Servicios();
            _entrega = new Entrega();
            var model_solicitud = crud_Solicitud.Mostrar_Solicitud_Por_Factura(facturacion.IdSolicitudFkFacturacion);

            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                //var obj_Entrega = dbcontext.Entrega;
                _entrega.IdFacturaFkEntrega = facturacion.Id;
                _entrega.IdClienteFkEntrega = facturacion.IdClienteFkFacturacion;
                _entrega.CantidadArticulos = model_solicitud.Cantidad;
                _entrega.CedulaQuienRecibe = model_solicitud.Cedula;
                _entrega.FechaDeEntrega = DateTime.Today;
                _entrega.Estatus = estatus_solicitud_entregada;
                dbcontext.Entrega.Add(_entrega);
                dbcontext.SaveChanges();
            }
        }

    }
}
