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
    public class Product
    {
        //[HiddenInput(DisplayValue = false)]
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }



        [DisplayName("Nombre Producto")]
        [Required(ErrorMessage = "Un nombre es requerido")]
        [StringLength(160)]
        public string Name { get; set; }


        [DisplayName("Marcar")]
        [Required(ErrorMessage = "Marca es requerida")]
        [ForeignKey("Brand")]
        //public int BrandId { get; set; }
        public int BrandId { get; set; }
        //public Brand Brand { get; set; }

        [DisplayName("Fecha de Vencimiento")]
        [Required(ErrorMessage = "Fecha de Vencimiento es requerido")]
        public DateTime Expiration_Date { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "Precio es requerido")]
        [Range(1.00, 99999999.99, ErrorMessage = "Precio validos desde 1 hasta 99999999")]
        public double  Unit_Price { get; set; }

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "Proveedor es requerido")]
        [ForeignKey("Provider")]
        //public int ProviderId { get; set; }
        public int ProviderId { get; set; }


        public virtual Brand Brand { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }



    }
}
