using Infraestrucura.Core.Comunes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.BoundedContext.AggregatePlanta;
using Infraestructura.BoundedContext.EntityTypeConfiguration;

namespace Infraestructura.BoundedContext.Comunes
{
    public class UnitOfWork:BCUnitOfWork
    {

        /// <summary>
        /// Inicializa mi UnitOfWork de acuerdo a la cadena de conexion para trabajar en la capa de infraestructura
        /// </summary>
        public UnitOfWork()
            :base("connectionString")
        {
            Database.SetInitializer<UnitOfWork>(null);
        }

        public IDbSet<Planta> Planta { get; set; }
        public IDbSet<Departamentos> Departamentos { get; set; }
        public IDbSet<Procesos> Procesos { get; set; }
        public IDbSet<ProcesosPorDepartamento> ProcesoPorDepartamento { get; set; }


        /// <summary>
        /// Agrega entityTypeConfigurations a mi modelo de BD
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PlantaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProcesosEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new DepartamentosEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProcesosPorDepartamentosEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
