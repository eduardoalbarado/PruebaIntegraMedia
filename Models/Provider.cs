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
    public class Provider
    {
        [Key]
        [DisplayName("Internal ID")]
        public int ID { get; set; }

        [DisplayName("Nombre del Proveedor")]
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(60)]
        public string Name { get; set; }

        [DisplayName("CUIL")]
        [Required(ErrorMessage = "CUIL es requerido, sin guiones")]
        [StringLength(11)]
        public string Cuil { get; set; }

        [DisplayName("Dirección")]
        [StringLength(128)]
        public string Address { get; set; }

        [DisplayName("Telefono")]
        [StringLength(15)]
        public string Phone { get; set; }


        [DisplayName("Celular")]
        [StringLength(15)]
        public string MobilePhone { get; set; }

        public virtual ICollection<Product> Productos { get; set; }


    }
}
