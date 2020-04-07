using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Calculo_De_Costo
{
    public class Calculo_De_Peso
    {
        private const float costo_del_peso_kg = 70;
        private const float costo_del_peso_lb = 100;
        private float costo;
        public Calculo_De_Peso()
        {
            // ....
        }
        public decimal Costo_Por_Peso(Solicitud solicitud) 
        {
            float peso = Convert.ToInt32(solicitud.Peso);
            //decimal costo = 0;
            if (solicitud.Cantidad > 5)
            {
                //Se calculara en kilogramo para hacer descuento a los usuarios de grandes cargas.
                costo = costo_del_peso_kg * Convert.ToInt32(solicitud.Cantidad);
                costo *= peso;
                return Convert.ToDecimal(costo);
            }
            //Se calculara en libras los cargametentos igual o menor a 5 libras
            costo = costo_del_peso_lb * Convert.ToInt32(solicitud.Cantidad);
            costo *= peso;
            return Convert.ToDecimal(costo);
        }
        //  Convirtiendo los datos enviados de texto a flotante.
        public float Conversion_Del_Peso(string peso)
        {
            //haciendo la conversion del peso.
            switch (peso)
            {
                case "NN":
                    return 0;
                    break;
                case "OLB":
                    return 1;
                    break;
                case "TWLB":
                    return 2;
                    break;
                case "TLB":
                    return 3;
                    break;
                case "FRLB":
                    return 4;
                    break;
                case "FLB":
                    return 5;
                    break;
                case "FKG":
                    return 11;
                    break;
                case "TKG":
                    return 22;
                    break;
                case "TWKG":
                    return 44;
                    break;
                default:
                    return 0;
                    break;
            }
        }
    }
}
