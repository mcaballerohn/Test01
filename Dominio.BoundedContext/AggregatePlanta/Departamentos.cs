using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.BoundedContext.AggregatePlanta
{
    public class Departamentos
    {
        public string PlantaId { get; set; }
        public string DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }
        public string Descripcion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaTransaccion { get; set; }
        public string DescripcionTransaccion { get; set; }
        public Guid? TransaccionUId { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime? FechaTransaccionUTc { get; set; }

        public virtual Planta PlantaVirtual { get; set; }

        public virtual ICollection<ProcesosPorDepartamento> ProcesosPorDepartamentoVirtual { get; set; }


        /// <summary>
        /// Metodo propio de la entidad que actualiza sus campos actualizables de acuerdo a la entidad de parametro
        /// </summary>
        /// <param name="deptos">Entidad que contiene los valores a modificar de la propia entidad</param>
        public void ActualizarDepartamento(Departamentos deptos)
        {
            NombreDepartamento = deptos.NombreDepartamento;
            Descripcion = deptos.Descripcion;          
        }
    }
}
