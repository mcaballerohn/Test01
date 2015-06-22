using Dominio.BoundedContext.AggregatePlanta;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.BoundedContext.EntityTypeConfiguration
{
    internal class ProcesosPorDepartamentosEntityTypeConfiguration : EntityTypeConfiguration<ProcesosPorDepartamento>
    {
        public ProcesosPorDepartamentosEntityTypeConfiguration()
        {
            HasKey(t => new {t.PlantaId, t.DepartamentoId, t.ProcesoId });
            ToTable("ProcesosPorDepartamentos", "Comunes");
            Property(t => t.PlantaId).HasColumnName("PlantaId").IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(t => t.DepartamentoId).HasColumnName("DepartamentoId").IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(t => t.ProcesoId).HasColumnName("ProcesoId").IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(t => t.ModificadoPor).HasColumnName("ModificadoPor").IsRequired().IsUnicode(false)
                .HasMaxLength(20);
            Property(t => t.FechaTransaccion).HasColumnName("FechaTransaccion");
            Property(t => t.DescripcionTransaccion).HasColumnName("DescripcionTransaccion").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.TransaccionUId).HasColumnName("TransaccionUId");
            Property(t => t.TipoTransaccion).HasColumnName("TipoTransaccion").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.FechaTransaccionUTc).HasColumnName("FechaTransaccionUtc");
          
            HasRequired(t => t.DepartamentosVirtuales).WithMany(c => c.ProcesosPorDepartamentoVirtual).HasForeignKey(t => new { t.PlantaId, t.DepartamentoId });
          
        }
    }
}
