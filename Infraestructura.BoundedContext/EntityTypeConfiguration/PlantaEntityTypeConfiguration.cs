using Dominio.BoundedContext.AggregatePlanta;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.BoundedContext.EntityTypeConfiguration
{
    internal class PlantaEntityTypeConfiguration : EntityTypeConfiguration<Planta>
    {
        public PlantaEntityTypeConfiguration()
        {
            HasKey(t => t.PlantaId);
            ToTable("Planta", "Comunes");
            Property(t => t.PlantaId).HasColumnName("PlantaId").IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(t => t.NombrePlanta).HasColumnName("NombrePlanta").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.Descripcion).HasColumnName("Descripcion").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.ModificadoPor).HasColumnName("ModificadoPor").IsRequired().IsUnicode(false)
                .HasMaxLength(20);
            Property(t => t.FechaTransaccion).HasColumnName("FechaTransaccion");
            Property(t => t.DescripcionTransaccion).HasColumnName("DescripcionTransaccion").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.TransaccionUId).HasColumnName("TransaccionUId");
            Property(t => t.TipoTransaccion).HasColumnName("TipoTransaccion").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.FechaTransaccionUTc).HasColumnName("FechaTransaccionUtc");
        }
    }
}
