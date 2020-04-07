using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class Enviar_Mercancia : IEnviar_Mercancia
    {
        private Solicitud _solicitud;
        private Facturacion _facturacion;
        private Envio _envio;

        public List<Envio> Listado_Envio(int id_solicitud)
        {
            throw new NotImplementedException();
        }

        public List<Envio> Listado_General_De_Envios()
        {
            var list = new List<Envio>();
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                list = dbcontext.Envio.ToList();
            }
            return list;
        }

        public Envio Realizar_Envio(Solicitud datos_de_la_solicitud)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                _facturacion = Validar_Fue_Facturado(datos_de_la_solicitud.Id);
                var obj_Envio = new Envio();
                obj_Envio.IdFacturaFkEnvio = _facturacion.Id;
                obj_Envio.IdClienteFkEnvio = datos_de_la_solicitud.IdClienteFkSolicitud;
                obj_Envio.CantidadArticulos = datos_de_la_solicitud.Cantidad;
                obj_Envio.FechaDeEnvio = DateTime.Today;
                obj_Envio.Estatus = datos_de_la_solicitud.Estatus;

                dbcontext.Envio.Add(obj_Envio);
                dbcontext.SaveChanges();
                _envio = obj_Envio;
            }
            return _envio;
        }

        public Solicitud Validar_Datos(string id_solicitud, string nombre_remitente, string nombre_receptor, string cedula_receptor)
        {
            CRUD_Solicitud_De_Servicios obj_Solicitud_Servicio = new CRUD_Solicitud_De_Servicios();
            string id_valido = (id_solicitud.Trim() != null) ? id_solicitud : null;
            if (int.Parse(id_valido) > 0 && id_valido != null)
            {
                int id = int.Parse(id_solicitud);
                var listado_solicitudes = obj_Solicitud_Servicio.Mostrar_Solicitudes().ToList();
                _solicitud = listado_solicitudes.Where(idSolicitud => idSolicitud.Id == id).FirstOrDefault();
                return _solicitud;
            }
            return null;
        }

        public Facturacion Validar_Fue_Facturado(int id_solicitud)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var model = dbcontext.Facturacion.Where(f => f.IdSolicitudFkFacturacion ==  id_solicitud).FirstOrDefault();
                _facturacion = model;
            }
            return _facturacion;
        }
    }
}
