using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.BoundedContext.AggregatePlanta
{
    public class Procesos
    {
        public string ProcesoId { get; set; }
        public string Proceso { get; set; }
        public string Descripcion { get; set; }        
        public string ModificadoPor { get; set; }
        public DateTime? FechaTransaccion { get; set; }
        public string DescripcionTransaccion { get; set; }
        public Guid? TransaccionUID { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime? FechaTransaccionUTC { get; set; }
    }
}
