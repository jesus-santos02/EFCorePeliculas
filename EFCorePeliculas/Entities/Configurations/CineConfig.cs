using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entities.Configurations
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
