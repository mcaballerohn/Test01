using Application.DTOs;
using Dominio.BoundedContext.AggregatePlanta;
using Infraestructura.BoundedContext.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios
{
    public class AppServiceProcesosPorDepartamentos
    {

        /// <summary>
        /// Propiedad privada del repositorio creado en infraestructura
        /// </summary>
         public DominioRepositorio _repoPlanta;

         /// <summary>
         /// constructor de la clase que inicializa el repositorio
         /// </summary>
         public AppServiceProcesosPorDepartamentos() 
        {
            _repoPlanta = new DominioRepositorio();
        }

        /// <summary>
         /// Metodo public que obtiene todos los Procesos por departamento
        /// </summary>
        /// <param name="procesoDeptoDto">DTO que contiene la informacion de la planta y departamento para poder devolver los proceso del departamento</param>
         /// <returns>Retorna un listado de los procesos por departamento de acuerdo la informacion del DTO sino devuelve una lista DTO vacia </returns>
        public List<ProcesosPorDepartamentosDto> ObtenerTodosLosProcesosPorDepartamento(ProcesosPorDepartamentosDto procesoDeptoDto)
        {
            var depto = _repoPlanta.ObtenerPlantaPorId(procesoDeptoDto.PlantaId).DepartamentosVirtual.FirstOrDefault
                (t=>t.DepartamentoId.Equals(procesoDeptoDto.DepartamentoId));    
            
            
            var ListaProcesoDepto = new List<ProcesosPorDepartamentosDto>();
            if (depto != null)
            {
                foreach (var proceso in depto.ProcesosPorDepartamentoVirtual)
                {
                    var procesoDto = new ProcesosPorDepartamentosDto()
                    {
                        PlantaId = proceso.PlantaId,
                        DepartamentoId = proceso.DepartamentoId,
                        ProcesoId = proceso.ProcesoId,
                    };
                    ListaProcesoDepto.Add(procesoDto);
                }
                return ListaProcesoDepto;
            }
            else 
            {
                return ListaProcesoDepto;
            }           
        }

        /// <summary>
        /// Metodo que agrega un nuevo Proceso a un departamento
        /// </summary>
        /// <param name="ProcesosDeptos">DTO que contiene la informacion del proceso que se quiere agregar al departamento</param>
        /// <returns>Retorna el Proceso agregado si la operacion fue exisotsa sino devuelve una instancia vacia del procesoPorDepartamento</returns>
        public ProcesosPorDepartamentosDto InsertProcesosPorDepto(ProcesosPorDepartamentosDto ProcesosDeptos)
        {
            var plantaActual = _repoPlanta.ObtenerPlantaPorId(ProcesosDeptos.PlantaId);

            bool procesoCorrecto = validarProceso(ProcesosDeptos.PlantaId, ProcesosDeptos.DepartamentoId,ProcesosDeptos.ProcesoId);

            if (procesoCorrecto)
            {
                var procesoPorDeptoEntidad = new ProcesosPorDepartamento()
                {
                    PlantaId = ProcesosDeptos.PlantaId,
                    DepartamentoId = ProcesosDeptos.DepartamentoId,
                    ProcesoId = ProcesosDeptos.ProcesoId,
                    ModificadoPor = "Usuario",
                    FechaTransaccion = DateTime.Now,
                    DescripcionTransaccion = "Transaccion",
                    TransaccionUId = Guid.NewGuid(),
                    TipoTransaccion = "Cambiable",
                    FechaTransaccionUTc = DateTime.Now
                };

                plantaActual.DepartamentosVirtual.FirstOrDefault
                            (t => t.DepartamentoId.Equals(ProcesosDeptos.DepartamentoId)).
                            ProcesosPorDepartamentoVirtual.Add(procesoPorDeptoEntidad);

                _repoPlanta.UoW.SaveChanges();
                return ProcesosDeptos;
            }
            else 
            {
                return new ProcesosPorDepartamentosDto();
            }           
        }

        /// <summary>
        /// Metodo que valida si la planta,departamento y proceso Es valido
        /// </summary>
        /// <param name="planta">Codigo de la planta a validar</param>
        /// <param name="depto">Codigo del departamento a validar</param>
        /// <param name="proceso">Codigo del proceso a validar</param>
        /// <returns>Retorna true si el codigo de palnta,departamento y proceso son validos o false si alguno o todos no lo son</returns>
        private bool validarProceso(string planta, string depto, string proceso)
        {
            bool plantaCorrecta = false;
            var plantaValidar = _repoPlanta.ObtenerPlantaPorId(planta);
            if (plantaValidar != null)
            {
                plantaCorrecta = true;
            }

            bool DeptoCorrecto = false;
            if (plantaCorrecta)
            {
                var deptoValidar = plantaValidar.DepartamentosVirtual.FirstOrDefault(t => t.DepartamentoId.Equals(depto));
                if (deptoValidar != null)
                {
                    DeptoCorrecto = true;
                }
            }

            bool procesoCorrecto = false;
            if (DeptoCorrecto) 
            {
                var procesoValidar = _repoPlanta.UoW.ProcesoPorDepartamento.FirstOrDefault(t => t.ProcesoId.Equals(proceso));
                if (DeptoCorrecto) 
                {
                    procesoCorrecto = true;
                }
            }

            if (plantaCorrecta && DeptoCorrecto && procesoCorrecto)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
