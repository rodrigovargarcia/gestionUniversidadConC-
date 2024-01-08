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
    public class CarreraController : Controller
    {
        // GET: Carrera
        public ActionResult Index()
        {
            List<CarreraTableViewModels> lst = null;
            using (gestion_universidadEntities db = new gestion_universidadEntities())
            {
                lst = (from d in db.carrera
                       orderby d.id
                       select new CarreraTableViewModels
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           DuracionAnios = d.duracion_anios,
                           Estado = d.estado
                       }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Add(CarrerasViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new gestion_universidadEntities())
            {
                carrera oCarrera = new carrera();
                oCarrera.nombre = model.Nombre;
                oCarrera.duracion_anios = model.DuracionAnios;
                oCarrera.estado = 1;

                db.carrera.Add(oCarrera);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Carrera"));
        }

        public ActionResult Edit(int id)
        {
            CarrerasEditViewModels model = new CarrerasEditViewModels();

            using(var db = new gestion_universidadEntities())
            {
                var oCarrera = db.carrera.Find(id);
                model.Nombre = oCarrera.nombre;
                model.DuracionAnios = (int)oCarrera.duracion_anios;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit (CarrerasEditViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            using(var db = new gestion_universidadEntities())
            {
                var oCarrera = db.carrera.Find(model.Id);
                oCarrera.nombre = model.Nombre;
                oCarrera.duracion_anios = model.DuracionAnios;

                db.Entry(oCarrera).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Carrera"));
        }

        public ActionResult Delete(int id)
        {
            var db = new gestion_universidadEntities();
            carrera oCarrera = db.carrera.Find(id);
            oCarrera.estado = 2;

            db.Entry(oCarrera).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Redirect(Url.Content("~/Carrera/"));
        }

        public ActionResult Dropped()
        {
            List<CarreraTableViewModels> lst = null;
            using (var db = new gestion_universidadEntities())
            {
                lst = (from d in db.carrera
                       where d.estado == 2
                       orderby d.id
                       select new CarreraTableViewModels
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           DuracionAnios = d.duracion_anios,
                           Estado = d.estado
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult Enable(int id)
        {
            var db = new gestion_universidadEntities();
            carrera oCarrera = db.carrera.Find(id);
            oCarrera.estado = 1;

            db.Entry(oCarrera).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Redirect(Url.Content("~/Carrera"));
        }
    }
}
