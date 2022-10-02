using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entities.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(p => p.Nombre)
                .HasMaxLength(150);
            builder.Property(p => p.FechaNacimiento)
                .HasColumnType("Date");

            builder.Property(p => p.Nombre)
                .HasField("_nombre");
        }
    }
}
