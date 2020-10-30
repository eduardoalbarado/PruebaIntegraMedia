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
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [DisplayName("Fecha de Facturación")]
        [Required(ErrorMessage = "Fecha de Vencimiento es requerido")]
        public System.DateTime OrderDate { get; set; }

        [DisplayName("Cliente")]
        public Client client { get; set; }

        [DisplayName("Vendedor")]
        public Employee employee { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }



    }
}
