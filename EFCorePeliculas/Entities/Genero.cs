using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
    //[Table("TablaGeneros", Schema = "Peliculas")]
    public class Genero
    {
        [Key]
        public int Identificador { get; set; }
        //[StringLength(150)]
        //[Required]
        //[Column(name:"NombreGenero")]
        public string Nombre { get; set; }
        public bool EstaBorrado { get; set; }   
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
