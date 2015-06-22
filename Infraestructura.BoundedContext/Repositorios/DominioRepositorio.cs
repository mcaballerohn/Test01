using Dominio.BoundedContext.AggregatePlanta;
using Dominio.BoundedContext.IRepositorios;
using Infraestructura.BoundedContext.Comunes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.BoundedContext.Repositorios
{
    public class DominioRepositorio : IRepositoryDominioGenerico
    {
        /// <summary>
        /// Propiedad public de mi UnitOfWork para trabajar en la BD
        /// </summary>
        public UnitOfWork UoW;


        public DominioRepositorio()
        {
            UoW = new UnitOfWork();
        }       

        /// <summary>
        /// Metodo global del repositorio para devolver una planta por ID
        /// </summary>
        /// <param name="plantaId">Codigo de la planta que se queire obtener</param>
        /// <returns>Planta obtenida de acuerdo al Id o null si no existe</returns>
        public Planta ObtenerPlantaPorId(string plantaId)
        {
            var planta = UoW.Planta.FirstOrDefault(x => x.PlantaId.Equals(plantaId));
            return planta;
        }


    }
}
