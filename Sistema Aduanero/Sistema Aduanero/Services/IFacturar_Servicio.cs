using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Aduanero.Models;

namespace Sistema_Aduanero.Services
{
    public interface IFacturar_Servicio
    {
        void Nuevo_Pago(Facturacion datos_facturados);
        Facturacion Validar_Forma_De_Pago(string metodo_de_pago, string no_solicitud, string tarjeta_de_credito,
                                       string codigo_cvv, string cuenta_bancaria, int id_cliente);
        string Pago_Por_Tarjeta(string metodo_de_pago, string tarjeta_de_credito, string codigo_cvv);
        string Pago_Por_Transferencia(string metodo_de_pago, string cuenta_bancaria);
        Solicitud Consultar_Solicitud(int id_solicitud);
        decimal Balance_De_La_Solicitud(int id_solicitud);
    }
}
