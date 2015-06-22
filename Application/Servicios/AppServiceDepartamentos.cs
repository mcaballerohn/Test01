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
    public class AppServiceDepartamentos
    {

        /// <summary>
        /// Propiedad privada del repositorio creado en infraestructura
        /// </summary>
         public DominioRepositorio _repoPlanta;

         /// <summary>
         /// constructor de la clase que inicializa el repositorio
         /// </summary>
        public AppServiceDepartamentos() 
        {
            _repoPlanta = new DominioRepositorio();
        }

        /// <summary>
        /// Metodo public que obtiene todos los departamentos por planta
        /// </summary>
        /// <param name="plantaId">Codigo de la planta de la cual se quiere obtener los departamentos</param>
        /// <returns>Retorna un listado de los departamentos de acuerdo al codigo de la palnta sino devuelve una lista DTO vacia</returns>
         public List<DepartamentosDto> ObtenerTodosLosDepartamentosPorPlanta(string plantaId)
        {

            var planta = _repoPlanta.ObtenerPlantaPorId(plantaId);

            if (planta == null) 
            {
                return new List<DepartamentosDto>();
            }

            var deptosPorPlanta = planta.DepartamentosVirtual.ToList();
            var ListaDeptos = new List<DepartamentosDto>();
            foreach (var depto in deptosPorPlanta)
            {
                var nuevoDeptodto = new DepartamentosDto()
                {
                    PlantaId = depto.PlantaId,
                    DepartamentoId = depto.DepartamentoId,
                    NombreDepartamento = depto.NombreDepartamento,
                    Descripcion = depto.Descripcion,
                    
                };
                ListaDeptos.Add(nuevoDeptodto);
            }
            return ListaDeptos;
        }


        /// <summary>
         /// Metodo que agrega un nuevo Departamento a una planta
        /// </summary>
         /// <param name="deptoDto">DTO que contiene la informacion del departamento que se quiere agregar a la planta</param>
         /// <returns>Retorna el departamento agregado si la operacion fue exisotsa sino devuelve una instancia vacia del departamento</returns>
        public DepartamentosDto InsertDepartamentos(DepartamentosDto deptoDto)
        {
            var plantaActual =_repoPlanta.ObtenerPlantaPorId(deptoDto.PlantaId);
             
            bool deptoCorrecto=validarDepartamento(deptoDto.PlantaId, deptoDto.DepartamentoId);

            if (deptoCorrecto)
            {
                var nuevoDeptoEntidad = new Departamentos()
                {
                    PlantaId = deptoDto.PlantaId,
                    DepartamentoId = deptoDto.DepartamentoId,
                    NombreDepartamento = deptoDto.NombreDepartamento,
                    Descripcion = deptoDto.Descripcion,
                    ModificadoPor = "USer",
                    FechaTransaccion = DateTime.Now,
                    DescripcionTransaccion = "Transaccion",
                    TransaccionUId = Guid.NewGuid(),
                    TipoTransaccion = "Cambiable",
                    FechaTransaccionUTc = DateTime.Now
                };
                plantaActual.DepartamentosVirtual.Add(nuevoDeptoEntidad);
                _repoPlanta.UoW.SaveChanges();
                return deptoDto;
            }else{
                return new DepartamentosDto();
            }
        }

        /// <summary>
        /// Metodo que valida si el codigo de la planta  y el departamento Es valido 
        /// </summary>
        /// <param name="planta">Codigo de mi planta a validar</param>
        /// <param name="depto">Codigo del departamento a validar</param>
        /// <returns>Retorna true si el codigo de palnta y departamento son validos o false si alguno o los dos no lo son</returns>
        private bool validarDepartamento(string planta, string depto)
        {
            bool plantaCorrecta=false;
 	        var plantaValidar=_repoPlanta.ObtenerPlantaPorId(planta);
            if(plantaValidar!=null)
            {
                plantaCorrecta=true;
            }

            bool DeptoCorrecto=false;
            if(plantaCorrecta)
            {                
                var deptoValidar=plantaValidar.DepartamentosVirtual.FirstOrDefault(t=> t.DepartamentoId.Equals(depto));
                if(deptoValidar!=null)
                {
                    DeptoCorrecto=true;
                }
            }

            if(plantaCorrecta && DeptoCorrecto){
                return true;
            }else
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza un departamento usando el metodo propio de la entidad de acuerdo a la informacion del DTO que recibe
        /// </summary>
        /// <param name="deptoDto">DTO que contiene la informacion que se debe modificar en el departamento</param>
        /// <returns>Retorna el departamentoDTO que se actualizo si la operacion fue exitosa sino una instacncia vacia</returns>
        public DepartamentosDto UpdateDepartamentos(DepartamentosDto deptoDto)
        {       
            var plantaActual =_repoPlanta.ObtenerPlantaPorId(deptoDto.PlantaId);
             
            bool deptoCorrecto=validarDepartamento(deptoDto.PlantaId, deptoDto.DepartamentoId);

            if (deptoCorrecto)
            {
                var deptoEntidad = new Departamentos()
                {
                    NombreDepartamento = deptoDto.NombreDepartamento,
                    Descripcion = deptoDto.Descripcion
                };

                plantaActual.DepartamentosVirtual.FirstOrDefault(
                    t => t.DepartamentoId.Equals(deptoDto.DepartamentoId)).ActualizarDepartamento(deptoEntidad);

                _repoPlanta.UoW.SaveChanges();
                return deptoDto;
            }
            else 
            {
                return new DepartamentosDto();
            }
        }


    }
}
