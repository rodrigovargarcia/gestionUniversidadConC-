using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionUniversidadC_.Models.ViewModels
{
    public class CarrerasViewModels
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Duración (años)")]
        [Range(1, int.MaxValue,ErrorMessage ="La duración debe ser un número positivo")]
        public int DuracionAnios { get; set; }
    }

    public class CarrerasEditViewModels
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Duración (años)")]
        [Range(1, int.MaxValue, ErrorMessage = "La duración debe ser un número positivo")]
        public int DuracionAnios { get; set; }
    }
}