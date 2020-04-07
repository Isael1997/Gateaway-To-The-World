using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Calculo_De_Costo
{
    public class Tipo_De_Mercancia
    {
        public string Validando_Tipo_De_Mercancia_o_Articulo(string mercancia) 
        {
            switch (mercancia)
            {
                case "NN":
                    return null;
                    break;
                case "SELECTS":
                    return "SELECTS";
                    break;
                case "SMS":
                    return "SMS";
                    break;
                case "STS":
                    return "STS";
                    break;
                case "SDES":
                    return "SDES";
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
