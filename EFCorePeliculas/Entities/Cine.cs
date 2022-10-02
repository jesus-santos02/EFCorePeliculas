using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entities
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }        
        public Point Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
    }

    //Relaciones entre Tablas =>
    ///Relacion Uno a Uno: Cine - CineOferta
    ///Relacion Uno a Muchos: Cine - SalaDeCine
    ///Relacion Muchos a Muchos: Pelicula - Genero, Pelicula - SalaDeCine
}
