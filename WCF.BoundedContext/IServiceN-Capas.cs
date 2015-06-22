using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.BoundedContext
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceN_Capas" in both code and config file together.
    [ServiceContract]
    public interface IServiceN_Capas
    {

        [OperationContract]
        List<PlantaDto> GetAllPlantas();

        [OperationContract]
        PlantaDto InsertarPlantas(PlantaDto plantaDto);

        [OperationContract]
        PlantaDto UpdatePlanta(PlantaDto plantaDto);

        [OperationContract]
        List<DepartamentosDto> ObtenerTodosLosDepartamentosPorPlanta(string plantaId);

        [OperationContract]
        DepartamentosDto InsertarDepartamentos(DepartamentosDto deptoDto);

        [OperationContract]
        DepartamentosDto UpdateDepartamentos(DepartamentosDto deptoDto);

        [OperationContract]
        List<ProcesosPorDepartamentosDto> OtenerTodosLosProcesosPorDepto(ProcesosPorDepartamentosDto procesoDeptoDto);

        [OperationContract]
        ProcesosPorDepartamentosDto InsertarProcesosPorDepto(ProcesosPorDepartamentosDto ProcesosDeptos);

        [OperationContract]
        List<ProcesosDto> ObtenerTodosLosProcesos();
       
    }
}
