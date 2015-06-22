using Dominio.BoundedContext.AggregatePlanta;
using Infraestructura.BoundedContext.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.BoundedContext.IRepositorios;
using Infraestructura.BoundedContext.Repositorios;
using Application;
using Application.DTOs;
using Application.Servicios;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            AppServiceProcesosPorDepartamentos app = new AppServiceProcesosPorDepartamentos();

            var lista = new ProcesosPorDepartamentosDto()
            {
                PlantaId = "HK",
                DepartamentoId = "010",
                ProcesoId = "NAPPER",                
            };

            app.InsertProcesosPorDepto(lista);
        }
    }
}
