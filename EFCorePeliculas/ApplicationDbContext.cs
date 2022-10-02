using EFCorePeliculas.Entities;
using EFCorePeliculas.Entities.Configurations;
using EFCorePeliculas.Entities.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }

        //Metodo para configurar por defecto el mapeo de un tipo de C# a un tipo de SQL.
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        //}

        //Cuando la ApiFluente crece demasiado, se hace favorable agrupar las configuraciones en varias clasesConfig
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tenemos 2 opciones para configurar la ApiFluente:

            ////Llamando cada clase Config de esta manera
            //modelBuilder.ApplyConfiguration(new GeneroConfig());

            //Llamando las clases que se estan ejecutando en el ensamblado, de esta manera escaneara el proyecto y agregara las clases
            //que implementen IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingModuloConsulta.Seed(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Genero>().HasKey(prop => prop.Identificador);
        //    modelBuilder.Entity<Genero>().Property(p => p.Nombre)
        //        .HasMaxLength(150)
        //        .IsRequired();

        //    modelBuilder.Entity<Actor>().Property(p => p.Nombre)
        //        .HasMaxLength(150);
        //    modelBuilder.Entity<Actor>().Property(p => p.FechaNacimiento)
        //        .HasColumnType("Date");

        //    modelBuilder.Entity<Cine>().Property(p => p.Nombre)
        //        .HasMaxLength(150)
        //        .IsRequired();

        //    modelBuilder.Entity<Pelicula>().Property(p => p.Titulo)
        //        .HasMaxLength(250)
        //        .IsRequired();
        //    modelBuilder.Entity<Pelicula>().Property(p => p.FechaEstreno)
        //        .HasColumnType("Date");
        //    modelBuilder.Entity<Pelicula>().Property(p => p.PosterURL)
        //        .HasMaxLength(500)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<CineOferta>().Property(p => p.FechaInicio)
        //        .HasColumnType("date");
        //    modelBuilder.Entity<CineOferta>().Property(p => p.FechaFin)
        //        .HasColumnType("date");
        //    modelBuilder.Entity<CineOferta>().Property(p => p.PorcentajeDescuento)
        //        .HasPrecision(precision: 5, scale: 2);

        //    modelBuilder.Entity<SalaDeCine>().Property(p => p.Precio)
        //        .HasPrecision(precision: 9, scale: 2);
        //    modelBuilder.Entity<SalaDeCine>().Property(p => p.TipoSalaDeCine)
        //        .HasDefaultValue(TipoSalaDeCine.DosDimensiones);

        //    modelBuilder.Entity<PeliculaActor>().HasKey(p => new { p.PeliculaId, p.ActorId });
        //    modelBuilder.Entity<PeliculaActor>().Property(p => p.Personaje)
        //        .HasMaxLength(150);
        //    //modelBuilder.Entity<Genero>().ToTable(name: "TablaPeliculas", schema: "Peliculas");
        //}
    }
}
