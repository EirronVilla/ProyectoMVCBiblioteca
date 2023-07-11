using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_MVC_AaronVillalobosArguedas.Models
{
    public class LibroSocio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("ID del Socio")]
        public string SocioId { get; set; }

        [DisplayName("ISBN del Libro")]
        public string LibroISBN { get; set; }

        [DisplayName("Fecha de Prestamo")]
        public DateTime FechaPrestamo { get; set; }

        [DisplayName("Fecha de Retorno")]
        public DateTime FechaRetorno { get; set; }

        [DisplayName("Prestamo Activo")]
        public bool Estado { get; set; }

        public LibroSocio() { 
            SocioId = String.Empty;
            LibroISBN = String.Empty;
            FechaPrestamo = DateTime.Now;
            FechaRetorno = FechaPrestamo.AddDays(5);
            Estado = true;
        }
    }
}
