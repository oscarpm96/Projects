using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    public class ClienteCLS
    {
        //--------- ID Cliente-------------
        [Display (Name = "ID Cliente")]
        public int iidcliente { get; set; }
        //---------- Nombre ------------
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(100,ErrorMessage = "100 es el maximo de caracteres" )]
        public string nombre { get; set; }
        //---------- ID Sexo ------------
        [Display(Name = "ID Sexo")]
        public int iidsexo { get; set; }
        //---------- Telefono --------------
        [Required]
        [StringLength(10, ErrorMessage = "Ya te pasaste karnal")]
        [Display (Name = "Telefono")]
        public string telefono { get; set; }


        //Propiedades adicionales
        [Display (Name = "Sexo")]
        public string NombreSexo { get; set; }
    }
}