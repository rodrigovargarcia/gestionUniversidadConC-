using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionUniversidadC_.Models.ViewModels
{
    public class MateriasViewModel
    {
        [Required]
        [Display(Name = "Nombre de la Materia")]
        public string NombreMateria { get; set; }

        [Required]
        [Display(Name = "Horas de cursado semanal")]
        public int? HorasCursado { get; set; }

        [Required]        
        public string Duracion { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public int? CarreraId { get; set; }
    }

    public class MateriasEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre de la Materia")]
        public string NombreMateria { get; set; }

        [Required]
        [Display(Name = "Horas de cursado semanal")]
        public int? HorasCursado { get; set; }

        [Required]
        public string Duracion { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public int? CarreraId { get; set; }
    }
}