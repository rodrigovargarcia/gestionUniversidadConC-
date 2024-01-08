using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionUniversidadC_.Models.TableViewModels
{
    public class CarreraTableViewModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  
        public int? DuracionAnios { get; set; }
        public int? Estado { get; set; } 
    }
}