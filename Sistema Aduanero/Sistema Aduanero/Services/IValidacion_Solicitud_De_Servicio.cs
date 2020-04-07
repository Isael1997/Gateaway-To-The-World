using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Services
{
    public interface IValidacion_Solicitud_De_Servicio
    {
        Solicitud Validar_Datos_A_Guardar(string tiempo_de_llegada, string servicios, string tipos_de_articulos,
            int cantidad, string peso_de_la_mercancia, string descripcion, string nombre_receptor,
            string cedula_receptor);
        string Tipo_De_Articulo(string tipo_de_articulo);
        float El_Peso(string el_peso_dado);
    }
}
