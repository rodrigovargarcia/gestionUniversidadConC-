using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionUniversidadC_.Models;
using gestionUniversidadC_.Models.TableViewModels;
using gestionUniversidadC_.Models.ViewModels;

namespace gestionUniversidadC_.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia

        public List<SelectListItem> ConvierteDropDown()
        {
            List<CarreraTableViewModels> lst = null;
            using (gestion_universidadEntities db = new gestion_universidadEntities())
            {
                lst = (from d in db.carrera where d.estado == 1
                       select new CarreraTableViewModels
                       {
                           Id = d.id,
                           Nombre = d.nombre
                       }).ToList();
            }
            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false,
                };
            });

            return ViewBag.items = items;
        }

        public ActionResult Index()
        {
            List<MateriaTableViewModels> lst = null;
            using (gestion_universidadEntities db = new gestion_universidadEntities())
            {
                lst = (from d in db.materia
                       join c in db.carrera on d.carrera_id equals c.id into carreras
                       from carrera in carreras.DefaultIfEmpty()
                       orderby d.id
                       select new MateriaTableViewModels
                       {
                           Id = d.id,
                           NombreMateria = d.nombre_materia,
                           HorasCursado = d.horas_cursado,
                           Duracion = d.duracion,
                           CarreraId = d.carrera_id,
                           NombreCarrera = (carrera != null) ? carrera.nombre : "No definida"
                       }).ToList();
            }
            
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {
            ConvierteDropDown();

            return View();
        }
        [HttpPost]
        public ActionResult Add(MateriasViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ConvierteDropDown();
                return View(model);
            }
            
            using (var db = new gestion_universidadEntities())
            {
                materia oMateria = new materia();
                oMateria.nombre_materia = model.NombreMateria;
                oMateria.horas_cursado = model.HorasCursado;
                oMateria.duracion = model.Duracion;
                oMateria.carrera_id = model.CarreraId;

                db.materia.Add(oMateria);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Materia"));
        }

        public ActionResult Edit(int id)
        {            
            var model = new MateriasEditViewModel();
            using (var db = new gestion_universidadEntities())
            {
                var oMateria = db.materia.Find(id);
                model.NombreMateria = oMateria.nombre_materia;
                model.HorasCursado = oMateria.horas_cursado;
                model.Duracion = oMateria.duracion;

                ConvierteDropDown();

                model.CarreraId = oMateria.carrera_id;

                //model.CarreraId = new List<SelectListItem>
                //{
                //    new SelectListItem{ Value = , Text = model.NombreMateria}
                //};
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit (MateriasEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ConvierteDropDown();
                return View(model);
            }

            using(var db = new gestion_universidadEntities())
            {
                materia oMateria = db.materia.Find(model.Id);
                oMateria.nombre_materia = model.NombreMateria;
                oMateria.horas_cursado = model.HorasCursado;
                oMateria.duracion = model.Duracion;
                oMateria.carrera_id = model.CarreraId;

                db.Entry(oMateria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Materia"));
        }

        public ActionResult Delete(int id)
        {
            var db = new gestion_universidadEntities();
            materia oMateria = db.materia.Find(id);
            db.materia.Remove(oMateria);
            db.SaveChanges();

            return Redirect(Url.Content("~/Materia")); 
        }
    }
}