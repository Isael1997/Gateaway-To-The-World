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
        private const string estatus_solicitud_facturada = "facturado";
        private const string estatus_solicitud_en_proceso = "Procesando";
        private List<Solicitud> _listas_solicitudes;
        public List<Solicitud> Mostrar_Solicitudes(int id_usuario)
        {
            //_solicitud = new Solicitud();
            _listas_solicitudes = new List<Solicitud>();
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var list = dbcontext.Solicitud.Where(s => s.IdClienteFkSolicitud == id_usuario).ToList();
                _listas_solicitudes = list;
            }
            return _listas_solicitudes;
        }

        //Nueva solicitud.
        public Solicitud Nueva_Solicitud(Solicitud model, int id_cliente)
        {
            _solicitud = new Solicitud();
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                _solicitud.TipoDeSolicitud = model.TipoDeSolicitud;
                _solicitud.TipoMercancia = model.TipoMercancia;
                _solicitud.Cantidad = model.Cantidad;
                _solicitud.Peso = model.Peso;
                _solicitud.Descripcion = model.Descripción;
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

        //Eliminar solicitud
        public void Eliminar_Solicitud(int id_solicitud)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var model = dbcontext.Solicitud.Find(id_solicitud);
                dbcontext.Solicitud.Remove(model);
                dbcontext.SaveChanges();
            }
        }

        public List<Solicitud> Mostrar_Solicitudes_Facturado()
        {
            var lista_solicitudes_facturadas = new List<Solicitud>();
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var consulta = dbcontext.Solicitud.Where(sFacturadas => sFacturadas.Estatus == estatus_solicitud_facturada).ToList();
                lista_solicitudes_facturadas = consulta;
            }
            return lista_solicitudes_facturadas;
        }
    }
}
