//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gestionUniversidadC_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class registro_materia_por_alumno
    {
        public int id { get; set; }
        public Nullable<int> materia_id { get; set; }
        public Nullable<int> alumno_id { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual materia materia { get; set; }
        public virtual alumno alumno { get; set; }
    }
}
