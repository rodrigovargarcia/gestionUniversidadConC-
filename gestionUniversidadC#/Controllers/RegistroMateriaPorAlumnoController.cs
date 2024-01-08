using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using gestionUniversidadC_.Models;
using gestionUniversidadC_.Models.TableViewModels;
using gestionUniversidadC_.Models.ViewModels;

namespace gestionUniversidadC_.Controllers
{
    public class RegistroMateriaPorAlumnoController : Controller
    {
        // GET: RegistoMateriaPorAlumno


        List<SelectListItem> ConvierteDropDownAlum()
        {
            List<AlumnoTableViewModels> lstAlum = null;
            using (gestion_universidadEntities db = new gestion_universidadEntities())
            {
                lstAlum = (from d in db.alumno where d.estado == 1 || d.estado == 2 
                           select new AlumnoTableViewModels
                           {
                               Id = d.id,
                               Nombre = d.nombre,
                           }).ToList();
            }

            List<SelectListItem> items2 = lstAlum.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false,
                };
            });

            return ViewBag.Items2 = items2;
        }


        List<SelectListItem> ConvierteDropDownMat()
        {
            List<MateriaTableViewModels> lstMat = null;

            using (gestion_universidadEntities db = new gestion_universidadEntities())
            {
                lstMat = (from d in db.materia
                          select new MateriaTableViewModels
                          {
                              Id = d.id,
                              NombreMateria = d.nombre_materia
                          }).ToList();
            }

            List<SelectListItem> items1 = lstMat.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreMateria.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            return ViewBag.Items = items1;
        }

        

        public ActionResult Index()
        {
            List<RegistroMateriaPorAlumnoTableViewModels> lst = null;
            using (gestion_universidadEntities db = new gestion_universidadEntities())
            {
                lst = (from d in db.registro_materia_por_alumno
                       join c in db.materia on d.materia_id equals c.id into materias
                       join e in db.alumno on d.alumno_id equals e.id into alumnos
                       from materia in materias.DefaultIfEmpty()
                       from alumno in alumnos.DefaultIfEmpty()
                       orderby d.id
                       select new RegistroMateriaPorAlumnoTableViewModels
                       {
                           Id = d.id,
                           Materia_Id = d.materia_id,
                           NombreMateria = (materia != null) ? materia.nombre_materia : "No definida",
                           Alumno_Id = d.alumno_id,
                           NombreAlumno = (alumno != null) ? alumno.nombre : "No definido",
                           Estado = d.estado,
                           Fecha = (DateTime)d.fecha,
                       }).ToList(); 
            }
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {
            ConvierteDropDownAlum();            
            return View();
        }

        public ActionResult Add(RegistrosMateriasPorAlumnoViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                ConvierteDropDownAlum();
                ConvierteDropDownMat();
                return View(modelo);
            }

            using (var db = new gestion_universidadEntities())
            {
                registro_materia_por_alumno oRegistro = new registro_materia_por_alumno();
                oRegistro.alumno_id = modelo.AlumnoId;
                oRegistro.materia_id = modelo.MateriaId;
                oRegistro.estado = modelo.Estado;
                oRegistro.fecha = modelo.Fecha;

                db.registro_materia_por_alumno.Add(oRegistro);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/RegistroMateriaPorAlumno"));
        }

        public ActionResult Edit(int id)
        {            
            var model = new RegistrosMateriasPorAlumnoEditViewModel();
            using(var db = new gestion_universidadEntities())
            {
                var oRegistro = db.registro_materia_por_alumno.Find(id);
                ConvierteDropDownMat();
                model.MateriaId = oRegistro.materia_id;
                ConvierteDropDownAlum();
                model.AlumnoId = oRegistro.alumno_id;
                model.Estado = oRegistro.estado;
                model.Fecha = oRegistro.fecha;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RegistrosMateriasPorAlumnoEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ConvierteDropDownAlum();
                ConvierteDropDownMat();
                return View(model);
            }

            using(var db = new gestion_universidadEntities())
            {
                registro_materia_por_alumno oRegistro = db.registro_materia_por_alumno.Find(model.Id);
                ConvierteDropDownMat();
                oRegistro.materia_id = model.MateriaId;
                ConvierteDropDownAlum();
                oRegistro.alumno_id = model.AlumnoId;
                oRegistro.estado = model.Estado;
                oRegistro.fecha = model.Fecha;

                db.Entry(oRegistro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/RegistroMateriaPorAlumno"));
        }

        public ActionResult Delete(int id)
        {
            var db = new gestion_universidadEntities();
            registro_materia_por_alumno oRegistro = db.registro_materia_por_alumno.Find(id);
            db.registro_materia_por_alumno.Remove(oRegistro);
            db.SaveChanges();

            return Redirect(Url.Content("~/RegistroMateriaPorAlumno"));
        }


        public JsonResult ObtenerCarreraIdPorAlumnoId(int alumnoId)
        {
            var db = new gestion_universidadEntities();
            // Lógica para obtener carrera_id asociado al Alumno seleccionado
            var carreraId = db.alumno
                            .Where(a => a.id == alumnoId)
                            .Select(a => a.carrera_id)
                            .FirstOrDefault();

            return Json(carreraId, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult ConvierteDropDownMatPorCarrera(int carreraId)
        {
            List<MateriaTableViewModels> lstMat = null;

            using (gestion_universidadEntities db = new gestion_universidadEntities())
            {
                lstMat = (from d in db.materia 
                          where d.carrera_id == carreraId
                          select new MateriaTableViewModels
                          {
                              Id = d.id,
                              NombreMateria = d.nombre_materia,
                              CarreraId = d.carrera_id
                          }).ToList();
            }

            return Json(lstMat, JsonRequestBehavior.AllowGet);
        }
    }
}