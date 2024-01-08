using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionUniversidadC_.Models.ViewModels
{
    public class RegistrosMateriasPorAlumnoViewModel
    {
        [Required]
        [Display(Name = "Materia")]
        public int? MateriaId { get; set; }

        [Required]
        [Display(Name = "Alumno")]
        public int? AlumnoId { get; set; }

        [Required]  
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime? Fecha { get; set; }
    }

    public class RegistrosMateriasPorAlumnoEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Materia")]
        public int? MateriaId { get; set; }

        [Required]
        [Display(Name = "Alumno")]
        public int? AlumnoId { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime? Fecha { get; set; }
    }
}