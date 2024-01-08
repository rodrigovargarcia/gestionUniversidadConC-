using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using gestionUniversidadC_.Models;
using gestionUniversidadC_.Models.TableViewModels;
using gestionUniversidadC_.Models.ViewModels;

namespace gestionUniversidadC_.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<UsuarioTableViewModel> lst = null;
            if (Session["Admin"] != null)
            {
                using (gestion_universidadEntities db = new gestion_universidadEntities())
                {
                    lst = (from d in db.usuario
                          where d.estado == 1
                          orderby d.id
                          select new UsuarioTableViewModel
                          {
                              Id = d.id,
                              Email = d.email,
                              Nombre = d.nombre,
                              Password = d.password,
                              Administrador = (bool)d.administrador,
                          }).ToList();
                }
                return View(lst);
            }
            else
            {
                return Redirect(Url.Content("~/Usuario/Error"));
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add (UsuariosViewModels model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using(var db = new gestion_universidadEntities())
            {
                usuario oUser = new usuario();
                oUser.estado = 1;
                oUser.email = model.Email;
                oUser.nombre = model.Nombre;
                oUser.password = model.Password;
                oUser.administrador = model.Administrador;

                db.usuario.Add(oUser);

                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Usuario"));
        }

        public ActionResult Edit(int id)
        {
            UsuariosEditViewModels model = new UsuariosEditViewModels();

            using (var db = new gestion_universidadEntities())
            {
                var oUsuario = db.usuario.Find(id);
                model.Nombre = oUsuario.nombre;
                model.Email = oUsuario.email;
                model.Administrador = (bool)oUsuario.administrador;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UsuariosEditViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new gestion_universidadEntities())
            {
                usuario oUser = db.usuario.Find(model.Id);
                //oUser.id = model.Id;
                oUser.estado = 1;
                oUser.email = model.Email;
                oUser.nombre = model.Nombre;

                if(model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }                                               
                oUser.administrador = model.Administrador;                

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Usuario"));
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var db = new gestion_universidadEntities();
            usuario oUsuario = db.usuario.Find(id);
            db.usuario.Remove(oUsuario);

            db.SaveChanges();

            return Redirect(Url.Content("~/Usuario"));
        }
    }
}