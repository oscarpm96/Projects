using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiPrimeraAplicacionWebConEntityFramework.Models;
using System.Web.Mvc;

namespace MiPrimeraAplicacionWebConEntityFramework.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            List<ClienteCLS> listaCliente = null;
            using (var bd = new SUPPLYEntities())
            {
                listaCliente = (from cliente in bd.MVC_Cliente
                                join Sexo in bd.MVC_Sexo on cliente.IdSexo equals
                                Sexo.IdSexo
                                where cliente.BHabilitado == 1
                                select new ClienteCLS
                                {
                                    iidcliente = cliente.IdCliente,
                                    nombre = cliente.Nombre,
                                    iidsexo = cliente.IdSexo,
                                    NombreSexo = Sexo.Nombre
                                }).ToList();
            }
            return View(listaCliente);
        }

        List<SelectListItem> listaSexo; //para llenar los campos de un comboBox
        private void llenarSexo()
        {
            using (var bd = new SUPPLYEntities())
            {
                listaSexo = (from sexo in bd.MVC_Sexo.AsEnumerable()
                             select new SelectListItem
                             {
                                 //SelectListItem tiene 2 propiedades (Text y Value):
                                 Text = sexo.Nombre, //Este es el campo a mostrar
                                 Value = sexo.IdSexo.ToString() //Este es el valor a mostrar
                             }).ToList();
                            //Se agrego un SelectListItem diciendo que estara en la posicion no [0] con el texto "Seleccione"
                listaSexo.Insert(0, new SelectListItem { Text = "--Seleccionar--", Value = "" });
            }
        }


        public ActionResult Agregar()
        {
            llenarSexo();
            ViewBag.lista = listaSexo; //Aqui se pasan los datos de la lista "listaSexo" a la vista "lista"


            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            if (!ModelState.IsValid) 
            {
                llenarSexo();
                ViewBag.lista = listaSexo;

                return View(oClienteCLS);
            }

            using (var bd = new SUPPLYEntities())
            {
                MVC_Cliente oCliente = new MVC_Cliente();
                oCliente.Nombre = oClienteCLS.nombre;
                oCliente.IdSexo = oClienteCLS.iidsexo;
                oCliente.BHabilitado = 1;
                oCliente.Telefono = oClienteCLS.telefono;
                bd.MVC_Cliente.Add(oCliente); //Agregamos todo el objeto oCliente con los campos de arriba
                bd.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
    }
}
