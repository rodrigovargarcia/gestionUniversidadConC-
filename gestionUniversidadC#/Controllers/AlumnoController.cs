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
    public class AlumnoController : Controller
    {
        // GET: Alumno

        public List<SelectListItem> ConvierteDropDown()
        {
            List<CarreraTableViewModels> lst = null;
            using (gestion_universidadEntities db2 = new gestion_universidadEntities())
            {
                lst = (from d in db2.carrera where d.estado == 1 
                       select new CarreraTableViewModels 
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           DuracionAnios = d.duracion_anios
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });
            return ViewBag.items = items;
            //return View(model);
        }

        public ActionResult Index()
        {
            List<AlumnoTableViewModels> lst = null;
            using(gestion_universidadEntities db = new gestion_universidadEntities())
            {
                lst = (from d in db.alumno
                       join c in db.carrera on d.carrera_id equals c.id into carreras
                       from carrera in carreras.DefaultIfEmpty()
                       orderby d.id
                       select new AlumnoTableViewModels
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Apellido = d.apellido,
                           Dni = d.dni,
                           Telefono = d.telefono,
                           Legajo = d.legajo,
                           Estado = d.estado,
                           Carrera_Id = d.carrera_id,
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
        
        public ActionResult Add(AlumnosViewModels model)
        {
            if (!ModelState.IsValid)
            {
                ConvierteDropDown();
                return View(model);
            }
            using (var db = new gestion_universidadEntities())
            {
                alumno oAlumno = new alumno();
                oAlumno.nombre = model.Nombre;
                oAlumno.apellido = model.Apellido;
                oAlumno.dni = model.Dni;
                oAlumno.telefono = model.Telefono;


                oAlumno.legajo = model.Legajo;
                oAlumno.estado = (int)model.Estado;
                oAlumno.carrera_id = model.CarreraId;

                db.alumno.Add(oAlumno);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Alumno"));
        }

        public ActionResult Edit(int id)
        {
            var model = new AlumnosEditViewModels();
            using(var db = new gestion_universidadEntities())
            {
                var oAlumno = db.alumno.Find(id);
                model.Nombre = oAlumno.nombre;
                model.Apellido = oAlumno.apellido;
                model.Dni = oAlumno.dni;
                model.Telefono = oAlumno.telefono;
                model.Legajo = oAlumno.legajo;
                model.Estado = oAlumno.estado;


                ConvierteDropDown();
                model.CarreraId = oAlumno.carrera_id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AlumnosEditViewModels model)
        {
            if (!ModelState.IsValid)
            {
                ConvierteDropDown();
                return View(model);
            }

            using(var db = new gestion_universidadEntities())
            {
                alumno oAlumno = db.alumno.Find(model.Id);
                oAlumno.nombre = model.Nombre;
                oAlumno.apellido = model.Apellido;
                oAlumno.dni = model.Dni;
                oAlumno.telefono = model.Telefono;
                oAlumno.legajo = model.Legajo;
                oAlumno.estado = model.Estado;
                oAlumno.carrera_id = model.CarreraId;

                db.Entry(oAlumno).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();   
            }

            return Redirect(Url.Content("~/Alumno"));
        }

        public ActionResult Delete(int id)
        {
            var db = new gestion_universidadEntities();
            alumno oAlumno = db.alumno.Find(id);
            oAlumno.estado = 3;

            db.Entry(oAlumno).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Redirect(Url.Content("~/Alumno"));
        }

        public ActionResult Dropped()
        {
            List<AlumnoTableViewModels> lst = null;
            using (var db = new gestion_universidadEntities())
            {
                lst = (from d in db.alumno
                       where d.estado == 3
                       join c in db.carrera on d.carrera_id equals c.id into carreras
                       from carrera in carreras.DefaultIfEmpty()
                       orderby d.id
                       select new AlumnoTableViewModels
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Apellido = d.apellido,
                           Dni = d.dni,
                           Telefono = d.telefono,
                           Legajo = d.legajo,
                           Estado = d.estado,
                           Carrera_Id = d.carrera_id,
                           NombreCarrera = (carrera != null) ? carrera.nombre : "No definida"
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult Enable(int id)
        {
            var db = new gestion_universidadEntities();
            alumno oAlumno = db.alumno.Find(id);
            oAlumno.estado = 1;

            db.Entry(oAlumno).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Redirect(Url.Content("~/Alumno"));
        }
    }
}