using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    public class SucursalCLS
    {
        //Los Display nos permite agregar un Alias a la columna de las tablas de SqlServer
        [Display(Name = "ID Sucursal")]
        public int iidsucursal { get; set; }


        [Display(Name = "Nombre Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Maxima 100")]
        public string nombre { get; set; }


        [Display(Name = "Direccion sucursal")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        public string direccion { get; set; }


        [Display(Name = "Telefono Sucursal")]
        [Required]
        [StringLength(10, ErrorMessage = "Longitud Maxima 10")]
        public string telefono { get; set; }


        [Display(Name = "Email Sucursal")]
        [Required]
        [EmailAddress(ErrorMessage ="Ingrese un Email valido")]
        [StringLength(100, ErrorMessage = "Longitud Maxima 100")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Date)] //Ayuda al EditorFor
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de apertura")]
        public DateTime fechaApertura { get; set; }


        public int bhabilitado { get; set; }
    }
}