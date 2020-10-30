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
    public class OrderDetail
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
    }
}
