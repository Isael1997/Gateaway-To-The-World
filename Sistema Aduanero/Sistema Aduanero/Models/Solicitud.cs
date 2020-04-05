using System;
using System.Collections.Generic;

namespace Sistema_Aduanero.Models
{
    public partial class Solicitud
    {
        public Solicitud()
        {
            Facturacion = new HashSet<Facturacion>();
        }

        public int Id { get; set; }
        public string TipoDeSolicitud { get; set; }
        public string TipoMercancia { get; set; }
        public int? Cantidad { get; set; }
        public double? Peso { get; set; }
        public string Descripción { get; set; }
        public string TiempoDeseadoEnLlegar { get; set; }
        public string NombreCompletoDeQuienRecibe { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaDeLaSolicitud { get; set; }
        public string Estatus { get; set; }
        public int IdClienteFkSolicitud { get; set; }
        public string PesoDeLaMercancia { get; set; }

        public Usuario IdClienteFkSolicitudNavigation { get; set; }
        public ICollection<Facturacion> Facturacion { get; set; }
    }
}
