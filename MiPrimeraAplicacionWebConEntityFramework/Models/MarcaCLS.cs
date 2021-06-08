using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    public class MarcaCLS
    {
        [Display(Name = "ID Marca")]
        public int iidmarca {get; set;}
        [Display(Name = "Nombre" )]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50 caracteres")]
        public string nombre {get; set;}
        [Display(Name = "Descripcion")]
        [Required]
        [StringLength(100, ErrorMessage = "La longitud maxima es de 100")]
        public string descripcion { get; set; }
        public string bhabilitado {get; set;}

    }
}