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

        [DisplayName("Fecha")]
        [Required(ErrorMessage = "Fecha es requerida")]
        public System.DateTime OrderDate { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "Cliente es requerido")]
        public int ClientID { get; set; }

        [DisplayName("Cliente")]
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }


        [DisplayName("Vendedor")]
        [Required(ErrorMessage = "Vender es requerido")]
        public int EmployeeID { get; set; }

        [DisplayName("Vendedor")]
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }



        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
