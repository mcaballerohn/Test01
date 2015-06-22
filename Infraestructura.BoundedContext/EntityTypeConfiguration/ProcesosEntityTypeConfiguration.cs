using Dominio.BoundedContext.AggregatePlanta;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.BoundedContext.EntityTypeConfiguration
{
    internal class ProcesosEntityTypeConfiguration : EntityTypeConfiguration<Procesos>
    {
        public ProcesosEntityTypeConfiguration()
        {
            HasKey(t => t.ProcesoId);
            ToTable("Procesos", "Comunes");
            Property(t => t.ProcesoId).HasColumnName("ProcesoId").IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(t => t.Proceso).HasColumnName("Proceso").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.Descripcion).HasColumnName("Descripcion").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(t => t.ModificadoPor).HasColumnName("ModificadoPor").IsRequired().IsUnicode(false)
                .HasMaxLength(20);
            Property(t => t.FechaTransaccion).HasColumnName("FechaTransaccion");
            Property(t => t.DescripcionTransaccion).HasColumnName("DescripcionTransaccion").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.TransaccionUID).HasColumnName("TransaccionUId");
            Property(t => t.TipoTransaccion).HasColumnName("TipoTransaccion").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.FechaTransaccionUTC).HasColumnName("FechaTransaccionUtc");            
        }
    }
}
