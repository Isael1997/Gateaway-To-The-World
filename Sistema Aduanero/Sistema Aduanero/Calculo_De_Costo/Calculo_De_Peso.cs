using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Calculo_De_Costo
{
    public class Calculo_De_Peso
    {
        public Calculo_De_Peso()
        {
            // ....
        }

        //public float Precio_Por_Libra()
        //{
        //    return
        //}

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
