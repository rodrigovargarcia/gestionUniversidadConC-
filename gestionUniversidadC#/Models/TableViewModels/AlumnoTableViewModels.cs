using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionUniversidadC_.Models.TableViewModels
{
    public class AlumnoTableViewModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public int? Legajo { get; set; }
        public int? Estado { get; set; }
        public int? Carrera_Id { get; set; }
        public string NombreCarrera { get; set; }
    }
}