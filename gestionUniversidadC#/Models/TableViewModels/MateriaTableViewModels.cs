using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionUniversidadC_.Models.TableViewModels
{
    public class MateriaTableViewModels
    {
        public int Id { get; set; } 
        public string NombreMateria { get; set; }
        public int? HorasCursado { get; set; }
        public string Duracion { get;set; }
        public int? CarreraId { get; set; } 
        public string NombreCarrera { get; set; }
    }
}