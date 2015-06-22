using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.BoundedContext.AggregatePlanta
{
    public class Planta
    {
        public string PlantaId { get; set; }
        public string NombrePlanta { get; set; }
        public string Descripcion { get; set; }
        public Guid? TransaccionUId { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime? FechaTransaccion { get; set; }
        public DateTime? FechaTransaccionUTc { get; set; }
        public string DescripcionTransaccion { get; set; }
        public string ModificadoPor { get; set; }

        public virtual ICollection<Departamentos> DepartamentosVirtual { get; set; }


        /// <summary>
        /// Metodo propio de la entidad que actualiza sus campos actualizables de acuerdo a la entidad de parametro
        /// </summary>
        /// <param name="planta">Entidad que contiene los valores a modificar de la propia entidad</param>
        public void ActualizarPlanta(Planta planta)
        {
            NombrePlanta = planta.NombrePlanta;
            Descripcion = planta.Descripcion;
            ModificadoPor = planta.ModificadoPor;
        }
        
    }
}
