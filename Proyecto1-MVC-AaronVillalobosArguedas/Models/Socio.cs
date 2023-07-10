﻿using System.ComponentModel.DataAnnotations;

namespace Proyecto1_MVC_AaronVillalobosArguedas.Models
{
    public class Socio
    {
        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
        public List<Libro>? Libros { get; }

        public Socio() { 
            Cedula = string.Empty;
            Nombre = string.Empty;
            Apellidos = string.Empty;
            FechaRegistro = DateTime.Now;
            Activo = false;
        }

        public Socio(
            string cedula, string nombre, 
            string apellidos, DateTime fechaRegistro, 
            bool activo)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaRegistro = fechaRegistro;
            Activo = activo;
        }
    }
}
