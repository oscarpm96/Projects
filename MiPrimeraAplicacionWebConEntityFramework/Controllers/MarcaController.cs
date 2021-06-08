using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWebConEntityFramework.Models;
namespace MiPrimeraAplicacionWebConEntityFramework.Controllers

{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            //La lista siempre se declara fuera del using
            List<MarcaCLS> listaMarca = null;
            //Dentro del using se declara el valor
            using (var bd=new SUPPLYEntities())
            {
                listaMarca = (from marca in bd.MVC_Marca
                              where marca.BHabilitado == 1
                              select new MarcaCLS
                              {
                               iidmarca = marca.IdMarca,
                               nombre = marca.Nombre,
                               descripcion = marca.Descripcion
                              }).ToList();
            }
            //Gracias a que la lista se declaro fuera del usingo el valor de la lista puede ser retornado
            return View(listaMarca);
        }
        //La siguiente linea hace la vista agregar
        public ActionResult Agregar()
        {
                return View();
        }

        public ActionResult Editar(int id) //Aqui pasamos el id del los items del index
        {
            MarcaCLS oMarcaCLS = new MarcaCLS();
            using (var bd = new SUPPLYEntities())
            {
               MVC_Marca oMarca = bd.MVC_Marca.Where(p => p.IdMarca.Equals(id)).First();
            }
            return View();
        }
        
        //La siguiente linea tiene el mismo nombre pero este hace la insercion a la vista agregar.
        [HttpPost]
        public ActionResult Agregar(MarcaCLS oMarcaCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oMarcaCLS);
            }else
            {
                using (var bd = new SUPPLYEntities())
                {
                    MVC_Marca oMarca = new MVC_Marca();
                    oMarca.Nombre = oMarcaCLS.nombre;
                    oMarca.Descripcion = oMarcaCLS.descripcion;
                    oMarca.BHabilitado = 1;
                    bd.MVC_Marca.Add(oMarca);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}