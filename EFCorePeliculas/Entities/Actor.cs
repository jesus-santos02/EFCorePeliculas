using RTools_NTS.Util;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entities
{
    public class Actor
    {
        private string _nombre;

        public int Id { get; set; }
        public string Nombre
        {
            get => _nombre;
            set => _nombre = string.Join(" ", value.Split(' ').Select(c => c[0].ToString().ToUpper() + c.Substring(1).ToLower()).ToArray());
        }
        public string Biografia { get; set; }
        //[Column(TypeName ="Date")]
        public DateTime? FechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
