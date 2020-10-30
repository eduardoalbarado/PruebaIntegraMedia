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
    public class Products
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }



        [DisplayName("Nombre Producto")]
        [Required(ErrorMessage = "Un nombre es requerido")]
        [StringLength(160)]
        public string Name { get; set; }


        [DisplayName("Marcar")]
        public int Marca { get; set; }

        [DisplayName("Fecha de Vencimiento")]
        [Required(ErrorMessage = "Fecha de Vencimiento es requerido")]
        public DateTime Expiration_Date { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "Precio es requerido")]
        [Range(1, 99999999, ErrorMessage = "Precio validos desde 1 hasta 99999999")]
        public decimal Unit_Price { get; set; }

        [DisplayName("Proveedor")]
        public int Provider { get; set; }

        public virtual Catagorie Catagorie { get; set; }



    }
}
