using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entities.Configurations
{
    public class CineOfertaConfig : IEntityTypeConfiguration<CineOferta>
    {
        public void Configure(EntityTypeBuilder<CineOferta> builder)
        {
            builder.Property(p => p.FechaInicio)
                .HasColumnType("date");
            builder.Property(p => p.FechaFin)
                .HasColumnType("date");
            builder.Property(p => p.PorcentajeDescuento)
                .HasPrecision(precision: 5, scale: 2);
        }
    }
}
