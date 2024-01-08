using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionUniversidadC_.Models.TableViewModels
{
    public class UsuarioTableViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Administrador { get; set; }
    }
}