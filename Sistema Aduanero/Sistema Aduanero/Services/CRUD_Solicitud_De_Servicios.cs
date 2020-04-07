using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class CRUD_Solicitud_De_Servicios : ICRUD_Solicitud_De_Servicios
    {
        private Solicitud _solicitud;
        private const string estatus_de_la_solicitud= "aún en el país de  origen.";
        public List<Solicitud> Mostrar_Solicitudes()
        {
            throw new NotImplementedException();
        }

        public Solicitud Nueva_Solicitud(Solicitud model, int id_cliente)
        {
            _solicitud = new Solicitud();
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                _solicitud.TipoDeSolicitud = model.TipoDeSolicitud;
                _solicitud.TipoMercancia = model.TipoMercancia;
                _solicitud.Cantidad = model.Cantidad;
                _solicitud.Peso = model.Peso;
                _solicitud.Descripción = model.Descripción;
                _solicitud.TiempoDeseadoEnLlegar = model.TiempoDeseadoEnLlegar;
                _solicitud.NombreCompletoDeQuienRecibe = model.NombreCompletoDeQuienRecibe;
                _solicitud.Cedula = model.Cedula;
                _solicitud.FechaDeLaSolicitud = model.FechaDeLaSolicitud;
                _solicitud.Estatus = estatus_de_la_solicitud;
                _solicitud.IdClienteFkSolicitud = id_cliente;
                dbcontext.Solicitud.Add(_solicitud);
                dbcontext.SaveChanges();
            }
            return _solicitud;
        }
        public Solicitud Editar_Solicitud()
        {
            throw new NotImplementedException();
        }

        public void Eliminar_Solicitud()
        {
            throw new NotImplementedException();
        }

    }
}
