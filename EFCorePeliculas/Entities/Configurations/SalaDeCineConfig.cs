using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entities.Configurations
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(p => p.Precio)
                .HasPrecision(precision: 9, scale: 2);
            builder.Property(p => p.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones);
        }
    }
}
