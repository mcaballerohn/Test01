using Dominio.BoundedContext.AggregatePlanta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.BoundedContext.IRepositorios
{
    public interface IRepositoryDominioGenerico
    {   
        /// <summary>
        /// Metodo que devuelve una planta por ID 
        /// </summary>
        /// <param name="plantaId">Codigo de la planta que quiere obtener</param>
        /// <returns>Entidad planta de acuerdo al codigo enviado de parametro o null si no existe</returns>
        Planta ObtenerPlantaPorId(string plantaId);
    }
}
