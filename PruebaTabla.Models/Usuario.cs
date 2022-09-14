using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTabla.Models
{
    [Table(name: "Usuarios")]
    public class Usuario
    {
        //ID
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Column("id")]
        [Display(Name = "Id del usuario")]
        public int Id { get; set; }

        //NOMBRE
        [StringLength(200)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Column("Nombre")]
        [Display(Name = "Nombre del usuario")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; } 
        
        [StringLength(200)]
        [Column("Nombre2")]
        [Display(Name = "Nombre del usuario")]
        [DataType(DataType.Text)]
        public string? Nombre2 { get; set; }

        //EDAD
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Edad del usuario")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Edad { get; set; }

        [Display(Name = "Edad del usuario")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Edad2 { get; set; }

        //FECHA INSCRIPCIÓN
        [Required(ErrorMessage = "El campo {0} es requerido")]
  
        [Display(Name = "Fecha de inscripción del usuario")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaInscripcion { get; set; }


        [Display(Name = "Fecha de inscripción del usuario")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaInscripcion2 { get; set; }

        //EMAIL
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string? Email2 { get; set; }

        //PASSWORD
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password2 { get; set; }

        //NÚMERO DECIMAL
        [Required(ErrorMessage = "El campo {0} es requerido")]
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal NumeroDecimal { get; set; }
       
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal? NumeroDecimal2 { get; set; }
    }
}
