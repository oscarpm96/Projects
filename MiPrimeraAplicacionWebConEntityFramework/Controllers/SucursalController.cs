using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWebConEntityFramework.Models;

namespace MiPrimeraAplicacionWebConEntityFramework.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<SucursalCLS> listaSucursal = null;
            using (var bd = new SUPPLYEntities())
            {
                listaSucursal = (from sucursal in bd.MVC_Sucursal2
                                 where sucursal.BHabilitado == 1
                                 select new SucursalCLS
                                 {
                                     iidsucursal = sucursal.IdSucursal,
                                     nombre = sucursal.Nombre,
                                     direccion = sucursal.Direccion,
                                     telefono = sucursal.Telefono,
                                     email = sucursal.Email,
                                     fechaApertura = (DateTime)sucursal.FechaApertura
                                 }).ToList();
            }
            return View(listaSucursal);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(SucursalCLS oSucursalCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oSucursalCLS); //Le pasamos el modelo oSucursal por si esta mal los datos no se borren
            }
            using (var bd = new SUPPLYEntities())
            {
                MVC_Sucursal2 oSucursal = new MVC_Sucursal2();
                oSucursal.Nombre = oSucursalCLS.nombre; //Insertamos en la base de datos con la instancia oSucursalCLS
                oSucursal.Direccion = oSucursalCLS.direccion;
                oSucursal.Telefono = oSucursalCLS.telefono;
                oSucursal.Email = oSucursalCLS.email;
                oSucursal.FechaApertura = oSucursalCLS.fechaApertura;
                oSucursal.BHabilitado = 1;
                bd.MVC_Sucursal2.Add(oSucursal); //oSucursal es el objeto que le vamos a agregar
                bd.SaveChanges();

            }
            return RedirectToAction("Index");

        }
    }
}