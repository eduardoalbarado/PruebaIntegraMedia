using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIntegraMedia.Models
{
    public class Client
    {
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(50)]
        public string First_Name { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(50)]
        public string Last_Name { get; set; }

        

    }
}
