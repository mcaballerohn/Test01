using Application.DTOs;
using Infraestructura.BoundedContext.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios
{
    public class AppServiceProcesos
    {
        /// <summary>
        /// Propiedad privada del repositorio creado en infraestructura
        /// </summary>
        public DominioRepositorio _repoPlanta;

        /// <summary>
        /// constructor de la clase que inicializa el repositorio
        /// </summary>
        public AppServiceProcesos() 
        {
            _repoPlanta = new DominioRepositorio();
        }

        /// <summary>
        /// Metodo public que obtiene todos los procesos de la BD
        /// </summary>
        /// <returns>Retorna un listado de los procesos en mi BD sino devuelve una lista DTO vacia</returns>
        public List<ProcesosDto> ObtenerTodosLosProcesos() 
        {
            var listaProcesosEntidad = _repoPlanta.UoW.Procesos.ToList();
            var listaProcesosDto=new List<ProcesosDto>();

            foreach (var proceso in listaProcesosEntidad) 
            {
                var nuevoProcesoDto = new ProcesosDto()
                {
                    IdProceso=proceso.ProcesoId,
                    NombreProceso=proceso.Proceso
                };
                listaProcesosDto.Add(nuevoProcesoDto);
            }
            return listaProcesosDto;
        }
    }
}
