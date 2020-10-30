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
    public class Brand
    {
        [Key]
        [DisplayName("Internal ID")]
        public int ID { get; set; }

        [DisplayName("Nombre del Proveedor")]
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(32)]
        public string Name { get; set; }

        [DisplayName("Nombre Corto")]
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(10)]
        public string Short_Name { get; set; }

        [DisplayName("Activo")]
        [DefaultValue(true)]
        public bool Enabled { get; set; }

        //public virtual ICollection<Product> Productos { get; set; }



    }
}
