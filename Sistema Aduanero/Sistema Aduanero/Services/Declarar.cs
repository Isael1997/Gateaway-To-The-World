using Sistema_Aduanero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Aduanero.Services
{
    public class Declarar : IDeclarar
    {
        private Solicitud _solicitud;
        private const string estatus_solicitud_en_proceso = "Procesando";
        public Solicitud Declarar_Solicitud(int id_solicitud)
        {
            if (id_solicitud <= 0)
            {
                return null;
            }
            using (var dbcontext = new DB_A5759C_gatewaytotheworldContext())
            {
                var obj_editable = dbcontext.Solicitud.Find(id_solicitud);
                obj_editable.Estatus = estatus_solicitud_en_proceso;
                dbcontext.Entry(obj_editable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChanges();
                _solicitud = obj_editable;
            }
            return _solicitud;
        }
    }
}
