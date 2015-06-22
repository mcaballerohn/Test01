using Application;
using Application.DTOs;
using Application.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.BoundedContext
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceN_Capas" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceN-Capas.svc or ServiceN-Capas.svc.cs at the Solution Explorer and start debugging.
    public class ServiceN_Capas : IServiceN_Capas
    {

        /// <summary>
        /// Propieda privada del appServicePlanta
        /// </summary>
        private AppServicePlantas _appServicePlanta;
        /// <summary>
        /// Propiedad privada del appServiceDepartamento
        /// </summary>
        private AppServiceDepartamentos _appServiceDepto;
        /// <summary>
        /// Propiedad privada del appServiceProcesoPorDepartamento
        /// </summary>
        private AppServiceProcesosPorDepartamentos _appServiceProcesosPorDepto;
        /// <summary>
        /// Propiedad privada del appServiceProcesos
        /// </summary>
        private AppServiceProcesos _appServiceProcesos;
        

        /// <summary>
        /// Constructor que instancia todas la propiedade privadas appService
        /// </summary>
        public ServiceN_Capas ()
    	{
            _appServicePlanta = new AppServicePlantas();
            _appServiceDepto=new AppServiceDepartamentos();
            _appServiceProcesosPorDepto=new AppServiceProcesosPorDepartamentos();
            _appServiceProcesos = new AppServiceProcesos();
    	}

        #region Planta

        /// <summary>
        /// Metodo del servicio que devuleve todas las plantas de la BD
        /// </summary>
        /// <returns>Retorna un listado de PlantaDto</returns>
        public List<PlantaDto> GetAllPlantas()
        {

            return _appServicePlanta.ObtenerTodasLasPlantas();
        }


        /// <summary>
        /// Metodo del servicio que inserta una planta a la BD
        /// </summary>
        /// <param name="plantaDto">DTO que contiene la informacion de la planta que se queire agregar</param>
        /// <returns>Retorna la PlantaDTO agregada si la operacion fue exisotsa sino devuelve una instancia vacia de la PlantaDTO</returns>
        public PlantaDto  InsertarPlantas(PlantaDto plantaDto)
        {
            if (!string.IsNullOrEmpty(plantaDto.PlantaId) && !string.IsNullOrEmpty(plantaDto.NombrePlanta)
                && !string.IsNullOrEmpty(plantaDto.Descripcion))
            {
                return _appServicePlanta.InsertPlantas(plantaDto);                
            }
            else 
            {
                return new PlantaDto();
            }
        }

        /// <summary>
        /// Metodo del servicio que actualzia una planta en la BD
        /// </summary>
        /// <param name="plantaDto">DTO que contiene la informacion de la planta que se quiere modificar</param>
        /// <returns>Retorna la plantaDTO que se inserto si la operacion fue exitosa sino una instacncia vacia de PlantaDTO</returns>
        public PlantaDto UpdatePlanta(PlantaDto plantaDto)
        {
            if (!string.IsNullOrEmpty(plantaDto.PlantaId) && !string.IsNullOrEmpty(plantaDto.NombrePlanta)
               && !string.IsNullOrEmpty(plantaDto.Descripcion))
            {
                return _appServicePlanta.UpdatePlanta(plantaDto);
            }
            else {
                return new PlantaDto();
            }
        }      

        #endregion

        #region Departamento

        /// <summary>
        /// Metodo del servicio que devuleve todos los departamentos de una planta
        /// </summary>
        /// <param name="plantaId">Codigo de la planta de la cual se quiere obtener los departamentos</param>
        /// <returns>Retorna un listado de los departamentos de acuerdo al codigo de la palnta sino devuelve una lista DTO vacia</returns>
        public List<DepartamentosDto> ObtenerTodosLosDepartamentosPorPlanta(string plantaId)
        {
            if (!string.IsNullOrEmpty(plantaId) )
            {
                return _appServiceDepto.ObtenerTodosLosDepartamentosPorPlanta(plantaId);
            }
            else {
                return new List<DepartamentosDto>();
            }
        }

        /// <summary>
        /// Metodo del servicio que agrega un departamento a una planta
        /// </summary>
        /// <param name="deptoDto">DTO que contiene la informacion del departamento que se quiere agregar a la planta</param>
        /// <returns>Retorna el departamento agregado si la operacion fue exisotsa sino devuelve una instancia vacia del departamentoDTO</returns>
        public DepartamentosDto InsertarDepartamentos(DepartamentosDto deptoDto)
        {
            if (!string.IsNullOrEmpty(deptoDto.DepartamentoId) && !string.IsNullOrEmpty(deptoDto.PlantaId)
                && !string.IsNullOrEmpty(deptoDto.Descripcion) && !string.IsNullOrEmpty(deptoDto.NombreDepartamento))
            {
                return _appServiceDepto.InsertDepartamentos(deptoDto);                
            }
            else 
            {
                return new DepartamentosDto();
            }
        }

        /// <summary>
        /// Metodo del servicio que actualiza un departamento de la planta
        /// </summary>
        /// <param name="deptoDto">DTO que contiene la informacion que se debe modificar en el departamento</param>
        /// <returns>Retorna el departamentoDTO que se actualizo si la operacion fue exitosa sino una instacncia vacia</returns>
        public DepartamentosDto UpdateDepartamentos(DepartamentosDto deptoDto)
        {
            if (!string.IsNullOrEmpty(deptoDto.DepartamentoId) && !string.IsNullOrEmpty(deptoDto.PlantaId)
                && !string.IsNullOrEmpty(deptoDto.Descripcion) && !string.IsNullOrEmpty(deptoDto.NombreDepartamento))
            {
                _appServiceDepto.UpdateDepartamentos(deptoDto);
                return deptoDto;
            }else
            {
                return new DepartamentosDto();
            }
            
        }

        #endregion

        #region ProcesosPorDepartamentos

        /// <summary>
        /// Metodo del servicio que devuleve todos los proceos de un departamento
        /// </summary>
        /// <param name="procesoDeptoDto">DTO que contiene la informacion de la planta y departamento para poder devolver los proceso del departamento</param>
        /// <returns>Retorna un listado de los procesos por departamento de acuerdo la informacion del DTO sino devuelve una lista DTO vacia </returns>
        public List<ProcesosPorDepartamentosDto> OtenerTodosLosProcesosPorDepto(ProcesosPorDepartamentosDto procesoDeptoDto)
        {
            if (!string.IsNullOrEmpty(procesoDeptoDto.PlantaId) && !string.IsNullOrEmpty(procesoDeptoDto.DepartamentoId))
                 //&& !string.IsNullOrEmpty(procesoDeptoDto.ProcesoId))
            {
                return _appServiceProcesosPorDepto.ObtenerTodosLosProcesosPorDepartamento(procesoDeptoDto);
            }
            else 
            {
                return new List<ProcesosPorDepartamentosDto>();
            }           
        }


        /// <summary>
        /// MEtodo del servicio que agrega un nuevo proceso a un departamento
        /// </summary>
        /// <param name="procesoDeptoDto">DTO que contiene la informacion del proceso que se quiere agregar al departamento</param>
        /// <returns>Retorna el ProcesoPorDeptoDTO agregado si la operacion fue exisotsa sino devuelve una instancia vacia del DTO</returns>
        public ProcesosPorDepartamentosDto InsertarProcesosPorDepto(ProcesosPorDepartamentosDto procesoDeptoDto)
        {
            if (!string.IsNullOrEmpty(procesoDeptoDto.PlantaId) && !string.IsNullOrEmpty(procesoDeptoDto.DepartamentoId)
                && !string.IsNullOrEmpty(procesoDeptoDto.ProcesoId))
            {
                return _appServiceProcesosPorDepto.InsertProcesosPorDepto(procesoDeptoDto);
            }
            else 
            {
                return new ProcesosPorDepartamentosDto();
            }  
        }      

        #endregion

        #region Procesos
        /// <summary>
        /// Metodo del servicio que devuleve todos los procesos maestros de la BD
        /// </summary>
        /// <returns>Retorna un listado de los procesosDTO en la BD sino devuelve una lista de DTO vacia</returns>
        public List<ProcesosDto> ObtenerTodosLosProcesos() 
        {
            return _appServiceProcesos.ObtenerTodosLosProcesos();
            
        }

        #endregion

    }
}
