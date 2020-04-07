using Sistema_Aduanero.Calculo_De_Costo;
using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class Facturar_Servicio : IFacturar_Servicio
    {
        private const string pago_por_tarjeta = "tarjeta";
        private const string transferencia_bancaria = "cuenta_bancaria";
        private const string estatus_facturado = "facturado";
        private Facturacion _facturacion;
        private Solicitud _solicitud;
        public void Nuevo_Pago(Facturacion datos_facturados)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                //  Facturando el servicio contratado.
                dbcontext.Facturacion.Add(datos_facturados);
                dbcontext.SaveChanges();

                // Cambiando el estado de la mercancia de "aún en el país de  origen." a: "Facturado".
                var obj_solicitud = dbcontext.Solicitud.Find(datos_facturados.IdSolicitudFkFacturacion);
                obj_solicitud.Estatus = estatus_facturado;
                dbcontext.Entry(obj_solicitud).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChanges();
            }
        }

        public Solicitud Consultar_Solicitud(int id_solicitud)
        {
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                _solicitud = dbcontext.Solicitud.Find(id_solicitud);
                if (_solicitud != null)
                {
                    return _solicitud;
                }
            }
            return null;
        }

        public string Pago_Por_Tarjeta(string metodo_de_pago, string tarjeta_de_credito, string codigo_cvv)
        {
            if (metodo_de_pago == pago_por_tarjeta && tarjeta_de_credito.Trim().Length == 16 &&
                codigo_cvv != null && codigo_cvv.Length == 3) 
            {
                return pago_por_tarjeta;
            }
            return null;
        }

        public string Pago_Por_Transferencia(string metodo_de_pago, string cuenta_bancaria)
        {
            if (metodo_de_pago == transferencia_bancaria && cuenta_bancaria.Trim().Length >= 7) 
            {
                return transferencia_bancaria;
            }
            return null;
        }

        public Facturacion Validar_Forma_De_Pago(string metodo_de_pago, string no_solicitud, string tarjeta_de_credito, 
                                                 string codigo_cvv, string cuenta_bancaria, int id_cliente)
        {
            _facturacion = new Facturacion();
            var obj_Calculo_De_Peso = new Calculo_De_Peso();

            string tarjeta = Pago_Por_Tarjeta(metodo_de_pago, tarjeta_de_credito, codigo_cvv);
            string transferencia = Pago_Por_Transferencia(metodo_de_pago, cuenta_bancaria);

            var datos_de_la_solicitud = Consultar_Solicitud(int.Parse(no_solicitud));

            if (tarjeta != null && datos_de_la_solicitud.Id > 0)
            {
                _facturacion.IdClienteFkFacturacion = id_cliente;
                _facturacion.TipoPago = tarjeta;
                _facturacion.IdSolicitudFkFacturacion = datos_de_la_solicitud.Id;
                _facturacion.FechaDeFacturacion = DateTime.Today;
                _facturacion.Balance = obj_Calculo_De_Peso.Costo_Por_Peso(datos_de_la_solicitud);
                return _facturacion;
            }
            else if (transferencia != null && datos_de_la_solicitud.Id > 0)
            {
                _facturacion.IdClienteFkFacturacion = id_cliente;
                _facturacion.TipoPago = transferencia;
                _facturacion.IdSolicitudFkFacturacion = datos_de_la_solicitud.Id;
                _facturacion.FechaDeFacturacion = DateTime.Today;
                _facturacion.Balance = obj_Calculo_De_Peso.Costo_Por_Peso(datos_de_la_solicitud);
                return _facturacion;
            }
            return null;
            //throw new NotImplementedException();
        }

        public decimal Balance_De_La_Solicitud(int id_solicitud)
        {
            throw new NotImplementedException();
        }
    }
}
