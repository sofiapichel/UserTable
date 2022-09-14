using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTabla.Frontend.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Nombre2")]
        public string? Nombre2 { get; set; }

        [Display(Name = "Edad")]
        public DateTime Edad { get; set; }

        [Display(Name = "Edad2")]
        public DateTime? Edad2 { get; set; }

        [Display(Name = "FechaInscripcion")]
        public DateTime FechaInscripcion { get; set; }

        [Display(Name = "FechaInscripcion2")]
        public DateTime? FechaInscripcion2 { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email2")]
        public string? Email2 { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Password")]
        public string? Password2 { get; set; }

        [Display(Name = "NumeroDecimal")]
        public decimal NumeroDecimal { get; set; }

        [Display(Name = "NumeroDecimal2")]
        public decimal? NumeroDecimal2 { get; set; }


    }
}
