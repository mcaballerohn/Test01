using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.BoundedContext.AggregatePlanta
{
    public class ProcesosPorDepartamento
    {
        public string PlantaId { get; set; }
        public string DepartamentoId { get; set; }
        public string ProcesoId { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaTransaccion { get; set; }
        public string DescripcionTransaccion { get; set; }
        public Guid? TransaccionUId { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime? FechaTransaccionUTc { get; set; }

        public virtual Departamentos DepartamentosVirtuales { get; set; }

    }
}
