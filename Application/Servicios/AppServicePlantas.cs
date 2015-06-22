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
    public class AppServicePlantas
    {
        /// <summary>
        /// Propiedad privada del repositorio creado en infraestructura
        /// </summary>
        private DominioRepositorio _repoPlanta;


        /// <summary>
        /// constructor de la clase que inicializa el repositorio
        /// </summary>
        public AppServicePlantas() 
        {
            _repoPlanta = new DominioRepositorio();
        }


        /// <summary>
        /// Metodo publico que obtiene todas las plantas de mi BD
        /// </summary>
        /// <returns>Retorna la lista de PlantaDto de mi BD o una lista vacia si hubo algun problema</returns>
         public List<PlantaDto> ObtenerTodasLasPlantas()
         {
             var ListaPlantaDto = new List<PlantaDto>();
             var listaPlantas =
                 (from platas in _repoPlanta.UoW.Planta
                  select platas).ToList();

             foreach (var plantaEntidad in listaPlantas)
             {
                 var nuevaPlantaDto = new PlantaDto()
                 {
                     PlantaId = plantaEntidad.PlantaId,
                     NombrePlanta = plantaEntidad.NombrePlanta,
                     Descripcion = plantaEntidad.Descripcion,                    
                 };
                 ListaPlantaDto.Add(nuevaPlantaDto);
             }
             return ListaPlantaDto;
         }
       
        /// <summary>
        /// Actualiza una planta usando el metodo propio de la entidad de acuerdo a la informacion del DTO que recibe
        /// </summary>
        /// <param name="plantaDto">DTO que contiene la informacion que se debe modificar en la planta</param>
        /// <returns>Retorna la plantaDTO que se inserto si la operacion fue exitosa sino una instacncia vacia</returns>
         public PlantaDto UpdatePlanta(PlantaDto plantaDto)
         {            
             bool existePlanta=validarPlanta(plantaDto.PlantaId);

             if (existePlanta)
             {
                 var plantaEntidad = new Planta()
                 {
                     NombrePlanta = plantaDto.NombrePlanta,
                     Descripcion = plantaDto.Descripcion,                     
                 };
                 var plantaRepositorio = _repoPlanta.ObtenerPlantaPorId(plantaDto.PlantaId);
                 plantaRepositorio.ActualizarPlanta(plantaEntidad);
                 _repoPlanta.UoW.SaveChanges();
                 return plantaDto;
             }
             else 
             {
                 return new PlantaDto();
             }
         }

        /// <summary>
        /// Metodo que valida si el codigo de mi planta Es valido 
        /// </summary>
         /// <param name="plantaId"> Codigo de mi planta a validar</param>
        /// <returns>Retorna True si la planta es valida o false si no lo es</returns>
         private bool validarPlanta(string plantaId)
         {
             var plantaValidacion = _repoPlanta.ObtenerPlantaPorId(plantaId);
             if (plantaValidacion==null)
             {
                 return false;
             }
             else 
             {
                 return true;
             }
         }

        /// <summary>
        /// Metodo que agrega una nueva Planta a mi BD
        /// </summary>
        /// <param name="plantaDto">DTO que contiene la informacion de la planta que quiero agregar a mi BD</param>
        /// <returns>Retorna la planta agregada si la operacion fue exisotsa sino devuelve una instancia vacia de la Planta</returns>
         public PlantaDto InsertPlantas(PlantaDto plantaDto)
         {
             bool existePlanta = validarPlanta(plantaDto.PlantaId);
             if (!existePlanta)
             {
                 var nuevaPlanta = new Planta()
                 {
                     PlantaId = plantaDto.PlantaId,
                     NombrePlanta = plantaDto.NombrePlanta,
                     Descripcion = plantaDto.Descripcion,
                     ModificadoPor = "User",
                     FechaTransaccion = DateTime.Now,
                     DescripcionTransaccion = "Transaccion",
                     TransaccionUId = Guid.NewGuid(),
                     TipoTransaccion = "Cambiable",
                     FechaTransaccionUTc = DateTime.Now
                 };
                 _repoPlanta.UoW.Planta.Add(nuevaPlanta);
                 _repoPlanta.UoW.SaveChanges();
                 return plantaDto;
             }
             else 
             {
                 return new PlantaDto();
             }
         }
        
    }
}
