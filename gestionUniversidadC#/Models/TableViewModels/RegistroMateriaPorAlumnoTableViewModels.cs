using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionUniversidadC_.Models.TableViewModels
{
    public class RegistroMateriaPorAlumnoTableViewModels
    {
        public int Id { get; set; } 
        public int? Materia_Id { get; set; }
        public int? Alumno_Id { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreMateria { get; set; }
        public string NombreAlumno { get; set; }
    }
}