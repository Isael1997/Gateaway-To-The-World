using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Aduanero.Calculo_De_Costo;

namespace Sistema_Aduanero.Services
{
    public class Validacion_Solicitud_De_Servicio : IValidacion_Solicitud_De_Servicio
    {
        private Solicitud _solicitud;
        public Validacion_Solicitud_De_Servicio()
        {
            //...
        }

        public float El_Peso(string el_peso_dado)
        {
            var obj_Calcular_Peso = new Calculo_De_Peso();
            //var peso =
            return obj_Calcular_Peso.Conversion_Del_Peso(el_peso_dado);
        }

        //Validando el tipo de articulo.
        public string Tipo_De_Articulo(string tipo_de_articulo)
        {
            var model = new Tipo_De_Mercancia();
            return model.Validando_Tipo_De_Mercancia_o_Articulo(tipo_de_articulo);
        }

        public Solicitud Validar_Datos_A_Guardar(string tiempo_de_llegada, string servicios, string tipos_de_articulos, 
            int cantidad, string peso_de_la_mercancia, string descripcion, string nombre_receptor,
            string cedula_receptor)
        {
            _solicitud = new Solicitud();
            if (tiempo_de_llegada != null && servicios != null && tipos_de_articulos != null && cantidad > 0 && 
                peso_de_la_mercancia != null && descripcion != null && nombre_receptor != null && cedula_receptor != null)
            {
                _solicitud.TipoDeSolicitud = servicios;
                _solicitud.TipoMercancia = tipos_de_articulos;
                _solicitud.Cantidad = cantidad;
                _solicitud.Peso = El_Peso(peso_de_la_mercancia); // Este valor sera asignado por el metodo que creare en otra clase.
                _solicitud.Descripción = descripcion;
                _solicitud.TiempoDeseadoEnLlegar = tiempo_de_llegada;
                _solicitud.NombreCompletoDeQuienRecibe = nombre_receptor;
                _solicitud.Cedula = cedula_receptor;
                _solicitud.FechaDeLaSolicitud = DateTime.Today; //  Este valor es subministrado por el sistema.
                _solicitud.Estatus = "";
                return _solicitud;
            }
            return _solicitud; //De retornar esta significa que algun dato es nulo
        }
    }
}
