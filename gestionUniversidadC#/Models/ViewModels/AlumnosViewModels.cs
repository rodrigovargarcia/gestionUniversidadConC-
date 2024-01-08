using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace gestionUniversidadC_.Models.ViewModels
{
    public class AlumnosViewModels
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Dni { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public int? Legajo { get; set; }

        [Required]
        public int? Estado { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public int? CarreraId { get; set; }
    }

    public class AlumnosEditViewModels
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Dni { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public int? Legajo { get; set; }

        [Required]
        public int? Estado { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public int? CarreraId { get; set; }
    }
}