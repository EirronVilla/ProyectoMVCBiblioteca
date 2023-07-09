using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_MVC_AaronVillalobosArguedas.Models
{
    public class LibroSocio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SocioId { get; set; }

        public string LibroISBN { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaRetorno { get; set; }

        public bool Estado { get; set; }

        public LibroSocio() { 
            SocioId = String.Empty;
            LibroISBN = String.Empty;
            FechaPrestamo = new DateTime();
            FechaRetorno = new DateTime();
            Estado = false;
        }
    }
}
