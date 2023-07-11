
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_MVC_AaronVillalobosArguedas.Models
{
    public class Libro
    {
        [Key]
        [MaxLength(100)]
        [DisplayName("ISBN")]
        public string ISBN { get; set; }

        [MaxLength(255)]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [MaxLength(100)]
        [DisplayName("Editorial")]
        public string Editorial { get; set; }

        [DisplayName("Edición")]
        public int Edicion { get; set; }

        [MaxLength(255)]
        [DisplayName("Autor")]
        public string Autor { get; set; }

        [DisplayName("Ejemplares Disponibles")]
        public int Disponibles { get; set; }

        public List<Socio>? Socios { get; }

        [NotMapped]
        public String LibroInfo
        {
            get
            {
                return String.Format("{0} ({1})", this.Titulo, this.ISBN);
            }
        }

        public Libro() { 
            ISBN = string.Empty;
            Titulo = string.Empty;
            Editorial = string.Empty;
            Edicion = 0;
            Autor = string.Empty;
            Disponibles = 0;
        }

        public Libro(
            string iSBN, string titulo,
            string editorial, int edicion,
            string autor, int disponibles)
        {
            ISBN = iSBN;
            Titulo = titulo;
            Editorial = editorial;
            Edicion = edicion;
            Autor = autor;
            Disponibles = disponibles;
        }
    }
}
